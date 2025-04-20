using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceReview(ICoreService<Review> coreService, IEmailService emailService, IValidator<Review> serviceReviewValidator) : IServiceReview
{
    /// <inheritdoc />
    public async Task<ResponseReviewDto> CreateAsync(RequestReviewDto request)
    {
        var serviceReview = await ValidateServiceReviewAsync(request);

        var result = await coreService.UnitOfWork.Repository<Review>().AddAsync(serviceReview);
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Feedback not saved");

        await emailService.SendReviewReceivedNotificationAsync(serviceReview);

        return coreService.AutoMapper.Map<ResponseReviewDto>(result);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseReviewDto>> GetAllAsync()
    {
        var list = await coreService.UnitOfWork.Repository<Review>().ListAllAsync();

        return coreService.AutoMapper.Map<ICollection<ResponseReviewDto>>(list);
    }

    /// <inheritdoc />
    public async Task<ResponseReviewDto> GetByIdAsync(long id)
    {
        var spec = new BaseSpecification<Review>(x => x.Id == id);
        var serviceReview = await coreService.UnitOfWork.Repository<Review>().FirstOrDefaultAsync(spec);

        if (serviceReview == null) throw new NotFoundException("Feedback not found");

        return coreService.AutoMapper.Map<ResponseReviewDto>(serviceReview);
    }

    /// <inheritdoc />
    public async Task<ResponseReviewDto> UpdateAsync(long id, RequestReviewDto request)
    {
        if (!await coreService.UnitOfWork.Repository<Review>().ExistsAsync(id)) throw new NotFoundException("Feedback not found");

        var serviceReview = await ValidateServiceReviewAsync(request, id);

        coreService.UnitOfWork.Repository<Review>().Update(serviceReview);
        await coreService.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    private async Task<Review> ValidateServiceReviewAsync(RequestReviewDto requestServiceReviewDto, long id = 0)
    {
        var serviceReview = coreService.AutoMapper.Map<Review>(requestServiceReviewDto);
        serviceReview.Created = DateTime.UtcNow;
        await serviceReviewValidator.ValidateAndThrowAsync(serviceReview);
        serviceReview.Id = id;

        return serviceReview;
    }
}