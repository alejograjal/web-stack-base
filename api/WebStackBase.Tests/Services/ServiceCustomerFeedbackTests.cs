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

namespace WebStackBase.Tests.Services;

public class ServiceCustomerFeedbackTests
{
    private readonly Mock<ICoreService<CustomerFeedback>> _mockCoreService;
    private readonly Mock<IValidator<CustomerFeedback>> _mockValidator;
    private readonly ServiceCustomerFeedback _service;

    public ServiceCustomerFeedbackTests()
    {
        _mockCoreService = new Mock<ICoreService<CustomerFeedback>>();
        _mockValidator = new Mock<IValidator<CustomerFeedback>>();

        _service = new ServiceCustomerFeedback(_mockCoreService.Object, _mockValidator.Object);
    }

    [Theory]
    [AutoData]
    public async Task CreateAsync_ShouldReturn_CustomerFeedbackDto(
        RequestCustomerFeedbackDto requestDto,
        CustomerFeedback customerFeedback,
        ResponseCustomerFeedbackDto responseDto
    )
    {
        _mockCoreService.Setup(v => v.AutoMapper.Map<CustomerFeedback>(requestDto)).Returns(customerFeedback);
        _mockCoreService.Setup(r => r.UnitOfWork.Repository<CustomerFeedback>().AddAsync(customerFeedback, true)).ReturnsAsync(customerFeedback);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(cs => cs.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback)).Returns(responseDto);

        // Act
        var result = await _service.CreateAsync(requestDto);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(r => r.AutoMapper.Map<CustomerFeedback>(requestDto), Times.Once);
        _mockCoreService.Verify(r => r.UnitOfWork.Repository<CustomerFeedback>().AddAsync(customerFeedback, true), Times.Once);
        _mockCoreService.Verify(u => u.UnitOfWork.SaveChangesAsync(), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task GetAllAsync_ShouldReturn_CustomerFeedbackDtoList(
        IList<CustomerFeedback> customerFeedbackList,
        ICollection<ResponseCustomerFeedbackDto> responseDtoList
    )
    {
        _mockCoreService.Setup(r => r.UnitOfWork.Repository<CustomerFeedback>().ListAllAsync()).ReturnsAsync(customerFeedbackList);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ICollection<ResponseCustomerFeedbackDto>>(customerFeedbackList)).Returns(responseDtoList);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().BeEquivalentTo(responseDtoList);
        _mockCoreService.Verify(r => r.UnitOfWork.Repository<CustomerFeedback>().ListAllAsync(), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ICollection<ResponseCustomerFeedbackDto>>(customerFeedbackList), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task GetByIdAsync_ShouldThrowNotFound_WhenNotFound(long id)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<CustomerFeedback>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<CustomerFeedback>>()))
            .ReturnsAsync((CustomerFeedback)null!);

        // Act
        Func<Task> action = async () => await _service.GetByIdAsync(id);

        // Assert
        await action.Should().ThrowAsync<NotFoundException>().WithMessage("Feedback not found");
    }

    [Theory]
    [AutoData]
    public async Task GetByIdAsync_ShouldReturn_CustomerFeedbackDto(long id, CustomerFeedback customerFeedback, ResponseCustomerFeedbackDto responseDto)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<CustomerFeedback>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<CustomerFeedback>>()))
            .ReturnsAsync(customerFeedback);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback)).Returns(responseDto);

        // Act
        var result = await _service.GetByIdAsync(id);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(repo => repo.UnitOfWork.Repository<CustomerFeedback>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<CustomerFeedback>>()), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task UpdateAsync_ShouldThrowNotFound_WhenNotFound(long id, RequestCustomerFeedbackDto request)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<CustomerFeedback>().ExistsAsync(id)).ReturnsAsync(false);

        // Act
        Func<Task> action = async () => await _service.UpdateAsync(id, request);

        // Assert
        await action.Should().ThrowAsync<NotFoundException>().WithMessage("Feedback not found");
    }

    [Theory]
    [AutoData]
    public async Task UpdateAsync_ShouldReturn_UpdatedCustomerFeedbackDto(long id, RequestCustomerFeedbackDto request, CustomerFeedback customerFeedback, ResponseCustomerFeedbackDto responseDto)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<CustomerFeedback>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.AutoMapper.Map<CustomerFeedback>(request)).Returns(customerFeedback);
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<CustomerFeedback>().Update(customerFeedback, true));
        _mockCoreService.Setup(repo => repo.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<CustomerFeedback>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<CustomerFeedback>>()))
            .ReturnsAsync(customerFeedback);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback)).Returns(responseDto);

        // Act
        var result = await _service.UpdateAsync(id, request);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(repo => repo.UnitOfWork.Repository<CustomerFeedback>().Update(customerFeedback, true), Times.Once);
        _mockCoreService.Verify(repo => repo.UnitOfWork.SaveChangesAsync(), Times.Once);
        _mockCoreService.Verify(m => m.AutoMapper.Map<ResponseCustomerFeedbackDto>(customerFeedback), Times.Once);
    }
}