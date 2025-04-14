using FluentValidation;
using WebStackBase.Domain.Exceptions;
using E = WebStackBase.Infrastructure;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceServiceResource(ICoreService<E.ServiceResource> coreService, IValidator<E.ServiceResource> serviceResourceValidator) : IServiceServiceResource
{
    /// <inheritdoc />
    public async Task<ResponseServiceResourceDto> CreateAsync(RequestServiceResourceDto request)
    {
        var serviceResource = await ValidateServiceResourceAsync(request);

        var result = await coreService.UnitOfWork.Repository<E.ServiceResource>().AddAsync(serviceResource);
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Resource not assigned");

        return coreService.AutoMapper.Map<ResponseServiceResourceDto>(result);
    }

    /// <inheritdoc />
    public async Task<bool> CreateAsync(IEnumerable<RequestServiceResourceDto> request)
    {
        var serviceResources = await ValidateServiceResourceAsync(request);

        var result = await coreService.UnitOfWork.Repository<E.ServiceResource>().AddRangeAsync(serviceResources.ToList());
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Resources not assigned");

        return true;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(long id)
    {
        var serviceResource = await coreService.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id);
        if (serviceResource == null) throw new NotFoundException("Resource assignation not found");

        coreService.UnitOfWork.Repository<E.ServiceResource>().Delete(serviceResource);
        await coreService.UnitOfWork.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseServiceResourceDto>> GetAllByResourceIdAsync(long resourceId)
    {
        var spec = new BaseSpecification<E.ServiceResource>(x => x.ResourceId == resourceId);
        var list = await coreService.UnitOfWork.Repository<E.ServiceResource>().ListAsync(spec);

        return coreService.AutoMapper.Map<ICollection<ResponseServiceResourceDto>>(list);
    }

    /// <inheritdoc />
    public async Task<ResponseServiceResourceDto> GetByIdAsync(long id)
    {
        var serviceResource = await coreService.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id);
        if (serviceResource == null) throw new NotFoundException("Resource assignation not found");

        return coreService.AutoMapper.Map<ResponseServiceResourceDto>(serviceResource);
    }

    /// <inheritdoc />
    public async Task<ResponseServiceResourceDto> UpdateAsync(long id, RequestServiceResourceDto request)
    {
        if (!await coreService.UnitOfWork.Repository<E.ServiceResource>().ExistsAsync(id)) throw new NotFoundException("Resource assignation not found");

        var serviceResource = await ValidateServiceResourceAsync(request, id);

        coreService.UnitOfWork.Repository<E.ServiceResource>().Update(serviceResource);
        await coreService.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    private async Task<E.ServiceResource> ValidateServiceResourceAsync(RequestServiceResourceDto requestServiceResourceDto, long id = 0)
    {
        var serviceResource = coreService.AutoMapper.Map<E.ServiceResource>(requestServiceResourceDto);

        await serviceResourceValidator.ValidateAndThrowAsync(serviceResource);
        serviceResource.Id = id;

        return serviceResource;
    }

    private async Task<IEnumerable<E.ServiceResource>> ValidateServiceResourceAsync(IEnumerable<RequestServiceResourceDto> requestServiceResourceDto)
    {
        var serviceResources = coreService.AutoMapper.Map<List<E.ServiceResource>>(requestServiceResourceDto);

        foreach (var item in serviceResources)
        {
            await serviceResourceValidator.ValidateAndThrowAsync(item);
        }

        return serviceResources;
    }
}