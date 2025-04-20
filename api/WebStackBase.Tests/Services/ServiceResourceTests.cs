using Moq;
using FluentAssertions;
using FluentValidation;
using E = WebStackBase.Infrastructure;
using WebStackBase.Tests.Attributes;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Implementations;

namespace WebStackBase.Tests.Services;

public class ServiceResourceTests
{
    private readonly Mock<ICoreService<E.Resource>> _mockCoreService;
    private readonly Mock<IValidator<E.Resource>> _mockValidator;
    private readonly ServiceResource _service;

    public ServiceResourceTests()
    {
        _mockCoreService = new Mock<ICoreService<E.Resource>>();
        _mockValidator = new Mock<IValidator<E.Resource>>();

        _service = new ServiceResource(_mockCoreService.Object, _mockValidator.Object);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_ShouldReturn_ResponseResourceDto(
        RequestResourceDto request,
        E.Resource resource,
        ResponseResourceDto response
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<E.Resource>(request)).Returns(resource);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().AddAsync(resource, true)).ReturnsAsync(resource);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseResourceDto>(resource)).Returns(response);

        var result = await _service.CreateAsync(request);

        result.Should().BeEquivalentTo(response);
        _mockCoreService.Verify(m => m.UnitOfWork.Repository<E.Resource>().AddAsync(resource, true), Times.Once);
        _mockCoreService.Verify(m => m.UnitOfWork.SaveChangesAsync(), Times.Once);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_ShouldThrow_WhenAddReturnsNull(
        RequestResourceDto request,
        E.Resource resource
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<E.Resource>(request)).Returns(resource);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().AddAsync(resource, true)).ReturnsAsync((E.Resource)null!);

        Func<Task> act = async () => await _service.CreateAsync(request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource not saved");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task DeleteAsync_ShouldMarkAsInactive_AndReturnTrue(
        long id,
        E.Resource resource
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().GetByIdAsync(id)).ReturnsAsync(resource);

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().Update(resource, true));
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());

        var result = await _service.DeleteAsync(id);

        result.Should().BeTrue();
        resource.IsActive.Should().BeFalse();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task DeleteAsync_ShouldThrowNotFound_WhenNotExists(long id)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().ExistsAsync(id)).ReturnsAsync(false);

        Func<Task> act = async () => await _service.DeleteAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetAllAsync_ShouldReturn_OnlyEnabledResources_WhenRequested(
        IList<E.Resource> resources,
        ICollection<ResponseResourceDto> responseDtos
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().ListAsync(It.IsAny<BaseSpecification<E.Resource>>()))
            .ReturnsAsync(resources);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ICollection<ResponseResourceDto>>(resources))
            .Returns(responseDtos);

        var result = await _service.GetAllAsync(true);

        result.Should().BeEquivalentTo(responseDtos);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldReturn_ResponseResourceDto(
        long id,
        E.Resource resource,
        ResponseResourceDto response
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().GetByIdAsync(id)).ReturnsAsync(resource);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseResourceDto>(resource)).Returns(response);

        var result = await _service.GetByIdAsync(id);

        result.Should().BeEquivalentTo(response);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldThrowNotFound_WhenNull(long id)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().GetByIdAsync(id)).ReturnsAsync((E.Resource?)null);

        Func<Task> act = async () => await _service.GetByIdAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldReturn_UpdatedResponseResourceDto(
        long id,
        RequestResourceDto request,
        E.Resource resource,
        ResponseResourceDto response
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.AutoMapper.Map<E.Resource>(request)).Returns(resource);

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().Update(resource, true));
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().GetByIdAsync(id)).ReturnsAsync(resource);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseResourceDto>(resource)).Returns(response);

        var result = await _service.UpdateAsync(id, request);

        result.Should().BeEquivalentTo(response);
        resource.Id.Should().Be(id);
        resource.IsActive.Should().BeTrue();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldThrowNotFound_WhenNotExists(
        long id,
        RequestResourceDto request
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.Resource>().ExistsAsync(id)).ReturnsAsync(false);

        Func<Task> act = async () => await _service.UpdateAsync(id, request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource not found");
    }
}