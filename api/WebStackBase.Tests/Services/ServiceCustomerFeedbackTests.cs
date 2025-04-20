using Moq;
using FluentAssertions;
using FluentValidation;
using AutoFixture.Xunit2;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Implementations;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Tests.Services;

public class ServiceCustomerFeedbackTests
{
    private readonly Mock<ICoreService<Review>> _mockCoreService;
    private readonly Mock<IValidator<Review>> _mockValidator;
    private readonly Mock<IEmailService> _mockEmailService;
    private readonly ServiceReview _service;

    public ServiceCustomerFeedbackTests()
    {
        _mockEmailService = new Mock<IEmailService>();
        _mockValidator = new Mock<IValidator<Review>>();
        _mockCoreService = new Mock<ICoreService<Review>>();

        _service = new ServiceReview(_mockCoreService.Object, _mockEmailService.Object, _mockValidator.Object);
    }

    [Theory]
    [AutoData]
    public async Task CreateAsync_ShouldReturn_CustomerFeedbackDto(
        RequestReviewDto requestDto,
        Review customerFeedback,
        ResponseReviewDto responseDto
    )
    {
        _mockCoreService.Setup(v => v.AutoMapper.Map<Review>(requestDto)).Returns(customerFeedback);
        _mockCoreService.Setup(r => r.UnitOfWork.Repository<Review>().AddAsync(customerFeedback, true)).ReturnsAsync(customerFeedback);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(cs => cs.AutoMapper.Map<ResponseReviewDto>(customerFeedback)).Returns(responseDto);

        // Act
        var result = await _service.CreateAsync(requestDto);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(r => r.AutoMapper.Map<Review>(requestDto), Times.Once);
        _mockCoreService.Verify(r => r.UnitOfWork.Repository<Review>().AddAsync(customerFeedback, true), Times.Once);
        _mockCoreService.Verify(u => u.UnitOfWork.SaveChangesAsync(), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ResponseReviewDto>(customerFeedback), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task GetAllAsync_ShouldReturn_CustomerFeedbackDtoList(
        IList<Review> customerFeedbackList,
        ICollection<ResponseReviewDto> responseDtoList
    )
    {
        _mockCoreService.Setup(r => r.UnitOfWork.Repository<Review>().ListAllAsync()).ReturnsAsync(customerFeedbackList);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ICollection<ResponseReviewDto>>(customerFeedbackList)).Returns(responseDtoList);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().BeEquivalentTo(responseDtoList);
        _mockCoreService.Verify(r => r.UnitOfWork.Repository<Review>().ListAllAsync(), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ICollection<ResponseReviewDto>>(customerFeedbackList), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task GetByIdAsync_ShouldThrowNotFound_WhenNotFound(long id)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Review>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Review>>()))
            .ReturnsAsync((Review)null!);

        // Act
        Func<Task> action = async () => await _service.GetByIdAsync(id);

        // Assert
        await action.Should().ThrowAsync<NotFoundException>().WithMessage("Feedback not found");
    }

    [Theory]
    [AutoData]
    public async Task GetByIdAsync_ShouldReturn_CustomerFeedbackDto(long id, Review customerFeedback, ResponseReviewDto responseDto)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Review>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Review>>()))
            .ReturnsAsync(customerFeedback);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseReviewDto>(customerFeedback)).Returns(responseDto);

        // Act
        var result = await _service.GetByIdAsync(id);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(repo => repo.UnitOfWork.Repository<Review>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Review>>()), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ResponseReviewDto>(customerFeedback), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task UpdateAsync_ShouldThrowNotFound_WhenNotFound(long id, RequestReviewDto request)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Review>().ExistsAsync(id)).ReturnsAsync(false);

        // Act
        Func<Task> action = async () => await _service.UpdateAsync(id, request);

        // Assert
        await action.Should().ThrowAsync<NotFoundException>().WithMessage("Feedback not found");
    }

    [Theory]
    [AutoData]
    public async Task UpdateAsync_ShouldReturn_UpdatedCustomerFeedbackDto(long id, RequestReviewDto request, Review customerFeedback, ResponseReviewDto responseDto)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Review>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.AutoMapper.Map<Review>(request)).Returns(customerFeedback);
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Review>().Update(customerFeedback, true));
        _mockCoreService.Setup(repo => repo.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Review>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Review>>()))
            .ReturnsAsync(customerFeedback);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseReviewDto>(customerFeedback)).Returns(responseDto);

        // Act
        var result = await _service.UpdateAsync(id, request);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(repo => repo.UnitOfWork.Repository<Review>().Update(customerFeedback, true), Times.Once);
        _mockCoreService.Verify(repo => repo.UnitOfWork.SaveChangesAsync(), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ResponseReviewDto>(customerFeedback), Times.Once);
    }
}