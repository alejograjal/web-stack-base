using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceService(ICoreService<Service> coreService, IValidator<Service> serviceValidator) : IServiceService
{
    /// <inheritdoc />
    public async Task<ResponseServiceDto> CreateAsync(RequestServiceDto request)
    {
        var service = await ValidateServiceAsync(request);

        var result = await coreService.UnitOfWork.Repository<Service>().AddAsync(service);
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Service not saved");

        return coreService.AutoMapper.Map<ResponseServiceDto>(result);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(long id)
    {
        if (!await coreService.UnitOfWork.Repository<Service>().ExistsAsync(id)) throw new NotFoundException("Service not found");

        var service = await coreService.UnitOfWork.Repository<Service>().GetByIdAsync(id);
        service!.IsActive = false;

        coreService.UnitOfWork.Repository<Service>().Update(service);
        await coreService.UnitOfWork.SaveChangesAsync();

        return true;
    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseServiceDto>> GetAllAsync()
    {
        var list = await coreService.UnitOfWork.Repository<Service>().ListAllAsync();

        return coreService.AutoMapper.Map<ICollection<ResponseServiceDto>>(list);
    }

    /// <inheritdoc />
    public async Task<ResponseServiceDto> GetByIdAsync(long id)
    {
        if (!await coreService.UnitOfWork.Repository<Service>().ExistsAsync(id)) throw new NotFoundException("Service not found");

        var service = await coreService.UnitOfWork.Repository<Service>().GetByIdAsync(id);

        return coreService.AutoMapper.Map<ResponseServiceDto>(service);
    }

    /// <inheritdoc />
    public async Task<ResponseServiceDto> UpdateAsync(long id, RequestServiceDto request)
    {
        if (!await coreService.UnitOfWork.Repository<Service>().ExistsAsync(id)) throw new NotFoundException("Service not found");

        var service = await ValidateServiceAsync(request, id);

        coreService.UnitOfWork.Repository<Service>().Update(service);
        await coreService.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    private async Task<Service> ValidateServiceAsync(RequestServiceDto requestServiceDto, long id = 0)
    {
        var service = coreService.AutoMapper.Map<Service>(requestServiceDto);
        await serviceValidator.ValidateAndThrowAsync(service);
        service.Id = id;
        service.IsActive = true;

        return service;
    }
}