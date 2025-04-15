using Moq;
using FluentAssertions;
using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Tests.Attributes;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Implementations;

namespace WebStackBase.Tests.Services;

public class ServiceServiceTests
{
    private readonly Mock<ICoreService<Service>> _mockCoreService;
    private readonly Mock<IValidator<Service>> _mockValidator;
    private readonly ServiceService _service;

    public ServiceServiceTests()
    {
        _mockCoreService = new Mock<ICoreService<Service>>();
        _mockValidator = new Mock<IValidator<Service>>();

        _service = new ServiceService(_mockCoreService.Object, _mockValidator.Object);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_ShouldReturn_ResponseServiceDto(
        RequestServiceDto request,
        Service serviceEntity,
        ResponseServiceDto responseDto
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<Service>(request)).Returns(serviceEntity);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().AddAsync(serviceEntity, true)).ReturnsAsync(serviceEntity);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseServiceDto>(serviceEntity)).Returns(responseDto);

        var result = await _service.CreateAsync(request);

        result.Should().BeEquivalentTo(responseDto);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_ShouldThrow_WhenResultIsNull(
        RequestServiceDto request,
        Service serviceEntity
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<Service>(request)).Returns(serviceEntity);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().AddAsync(serviceEntity, true)).ReturnsAsync((Service?)null);

        Func<Task> act = async () => await _service.CreateAsync(request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Service not saved");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task DeleteAsync_ShouldSetInactive_AndReturnTrue(
        long id,
        Service serviceEntity
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().GetByIdAsync(id)).ReturnsAsync(serviceEntity);

        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());

        var result = await _service.DeleteAsync(id);

        result.Should().BeTrue();
        serviceEntity.IsActive.Should().BeFalse();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task DeleteAsync_ShouldThrow_WhenNotExists(long id)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ExistsAsync(id)).ReturnsAsync(false);

        Func<Task> act = async () => await _service.DeleteAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Service not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetAllAsync_ShouldReturn_AllServices(
        IList<Service> services,
        ICollection<ResponseServiceDto> expectedDtos
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ListAllAsync()).ReturnsAsync(services);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ICollection<ResponseServiceDto>>(services)).Returns(expectedDtos);

        var result = await _service.GetAllAsync();

        result.Should().BeEquivalentTo(expectedDtos);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldReturn_ResponseDto(
        long id,
        Service serviceEntity,
        ResponseServiceDto expectedDto
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().GetByIdAsync(id)).ReturnsAsync(serviceEntity);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseServiceDto>(serviceEntity)).Returns(expectedDto);

        var result = await _service.GetByIdAsync(id);

        result.Should().BeEquivalentTo(expectedDto);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldThrow_WhenNotExists(long id)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ExistsAsync(id)).ReturnsAsync(false);

        Func<Task> act = async () => await _service.GetByIdAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Service not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldReturn_UpdatedDto(
        long id,
        RequestServiceDto request,
        Service serviceEntity,
        ResponseServiceDto expectedDto
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.AutoMapper.Map<Service>(request)).Returns(serviceEntity);

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().Update(serviceEntity, true));
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().GetByIdAsync(id)).ReturnsAsync(serviceEntity);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseServiceDto>(serviceEntity)).Returns(expectedDto);

        var result = await _service.UpdateAsync(id, request);

        result.Should().BeEquivalentTo(expectedDto);
        serviceEntity.Id.Should().Be(id);
        serviceEntity.IsActive.Should().BeTrue();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldThrow_WhenNotExists(long id, RequestServiceDto request)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<Service>().ExistsAsync(id)).ReturnsAsync(false);

        Func<Task> act = async () => await _service.UpdateAsync(id, request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Service not found");
    }
}
