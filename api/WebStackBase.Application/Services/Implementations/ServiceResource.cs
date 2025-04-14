using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceResource(ICoreService<Resource> coreService, IValidator<Resource> resourceValidator) : IServiceResource
{
    /// <inheritdoc />
    public async Task<ResponseResourceDto> CreateAsync(RequestResourceDto request)
    {
        var resource = await ValidateResourceAsync(request);

        var result = await coreService.UnitOfWork.Repository<Resource>().AddAsync(resource);
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Resource not saved");

        return coreService.AutoMapper.Map<ResponseResourceDto>(result);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(long id)
    {
        if (!await coreService.UnitOfWork.Repository<Resource>().ExistsAsync(id)) throw new NotFoundException("Resource not found");

        var resource = await coreService.UnitOfWork.Repository<Resource>().GetByIdAsync(id);
        resource!.IsActive = false;

        coreService.UnitOfWork.Repository<Resource>().Update(resource);
        await coreService.UnitOfWork.SaveChangesAsync();

        return true;

    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseResourceDto>> GetAllAsync(bool onlyEnabled = true)
    {
        var spec = new BaseSpecification<Resource>(x => !onlyEnabled || x.IsEnabled);

        var list = await coreService.UnitOfWork.Repository<Resource>().ListAsync(spec);

        return coreService.AutoMapper.Map<ICollection<ResponseResourceDto>>(list);
    }

    /// <inheritdoc />
    public async Task<ResponseResourceDto> GetByIdAsync(long id)
    {
        var resource = await coreService.UnitOfWork.Repository<Resource>().GetByIdAsync(id);
        if (resource == null) throw new NotFoundException("Resource not found");

        return coreService.AutoMapper.Map<ResponseResourceDto>(resource);
    }

    /// <inheritdoc />
    public async Task<ResponseResourceDto> UpdateAsync(long id, RequestResourceDto request)
    {
        if (!await coreService.UnitOfWork.Repository<Resource>().ExistsAsync(id)) throw new NotFoundException("Resource not found");

        var resource = await ValidateResourceAsync(request, id);

        coreService.UnitOfWork.Repository<Resource>().Update(resource);
        await coreService.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    private async Task<Resource> ValidateResourceAsync(RequestResourceDto requestResourceDto, long id = 0)
    {
        var resource = coreService.AutoMapper.Map<Resource>(requestResourceDto);

        await resourceValidator.ValidateAndThrowAsync(resource);
        resource.Id = id;
        resource.IsActive = true;

        return resource;
    }
}