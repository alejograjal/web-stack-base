using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceCustomerFeedback(ICoreService<CustomerFeedback> coreService, IValidator<CustomerFeedback> customerFeedbackValidator) : IServiceCustomerFeedback
{
    /// <inheritdoc />
    public async Task<ResponseCustomerFeedbackDto> CreateAsync(RequestCustomerFeedbackDto request)
    {
        var customerFeedback = await ValidateCustomerFeedbackAsync(request);

        var result = await coreService.UnitOfWork.Repository<CustomerFeedback>().AddAsync(customerFeedback);
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Feedback not saved");

        return coreService.AutoMapper.Map<ResponseCustomerFeedbackDto>(result);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseCustomerFeedbackDto>> GetAllAsync()
    {
        var list = await coreService.UnitOfWork.Repository<CustomerFeedback>().ListAllAsync();

        return coreService.AutoMapper.Map<ICollection<ResponseCustomerFeedbackDto>>(list);
    }

    /// <inheritdoc />
    public async Task<ResponseCustomerFeedbackDto> GetByIdAsync(long id)
    {
        var spec = new BaseSpecification<CustomerFeedback>(x => x.Id == id);
        var customerFeedback = await coreService.UnitOfWork.Repository<CustomerFeedback>().FirstOrDefaultAsync(spec);

        if (customerFeedback == null) throw new NotFoundException("Feedback not found");

        return coreService.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback);
    }

    /// <inheritdoc />
    public async Task<ResponseCustomerFeedbackDto> UpdateAsync(long id, RequestCustomerFeedbackDto request)
    {
        if (!await coreService.UnitOfWork.Repository<CustomerFeedback>().ExistsAsync(id)) throw new NotFoundException("Feedback not found");

        var customerFeedback = await ValidateCustomerFeedbackAsync(request, id);

        coreService.UnitOfWork.Repository<CustomerFeedback>().Update(customerFeedback);
        await coreService.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    private async Task<CustomerFeedback> ValidateCustomerFeedbackAsync(RequestCustomerFeedbackDto requestCustomerFeedbackDto, long id = 0)
    {
        var customerFeedback = coreService.AutoMapper.Map<CustomerFeedback>(requestCustomerFeedbackDto);
        await customerFeedbackValidator.ValidateAndThrowAsync(customerFeedback);
        customerFeedback.Id = id;

        return customerFeedback;
    }
}