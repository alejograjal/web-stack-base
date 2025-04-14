using Moq;
using FluentAssertions;
using FluentValidation;
using AutoFixture.Xunit2;
using WebStackBase.Infrastructure;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
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

}