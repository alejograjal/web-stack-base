using Moq;
using FluentAssertions;
using FluentValidation;
using WebStackBase.Tests.Attributes;
using WebStackBase.Domain.Exceptions;
using E = WebStackBase.Infrastructure;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Implementations;

namespace WebStackBase.Tests.Services;

public class ServiceServiceResourceTests
{
    private readonly Mock<ICoreService<E.ServiceResource>> _mockCoreService;
    private readonly Mock<IValidator<E.ServiceResource>> _mockValidator;
    private readonly ServiceServiceResource _service;

    public ServiceServiceResourceTests()
    {
        _mockCoreService = new Mock<ICoreService<E.ServiceResource>>();
        _mockValidator = new Mock<IValidator<E.ServiceResource>>();

        _service = new ServiceServiceResource(_mockCoreService.Object, _mockValidator.Object);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_Single_ShouldReturn_ResponseDto(
        RequestServiceResourceDto request,
        E.ServiceResource entity,
        ResponseServiceResourceDto responseDto
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<E.ServiceResource>(request)).Returns(entity);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().AddAsync(entity, true)).ReturnsAsync(entity);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseServiceResourceDto>(entity)).Returns(responseDto);

        var result = await _service.CreateAsync(request);

        result.Should().BeEquivalentTo(responseDto);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_Single_ShouldThrow_WhenAddReturnsNull(
        RequestServiceResourceDto request,
        E.ServiceResource entity
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<E.ServiceResource>(request)).Returns(entity);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().AddAsync(entity, true)).ReturnsAsync((E.ServiceResource)null!);

        Func<Task> act = async () => await _service.CreateAsync(request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource not assigned");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_Multiple_ShouldReturnTrue(
        List<RequestServiceResourceDto> request,
        List<E.ServiceResource> entities
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<List<E.ServiceResource>>(request)).Returns(entities);

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().AddRangeAsync(It.IsAny<List<E.ServiceResource>>(), true))
                        .ReturnsAsync(entities);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());

        var result = await _service.CreateAsync(request);

        result.Should().BeTrue();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_Multiple_ShouldThrow_WhenAddRangeReturnsNull(
        List<RequestServiceResourceDto> request,
        List<E.ServiceResource> entities
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<List<E.ServiceResource>>(request)).Returns(entities);

        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().AddRangeAsync(It.IsAny<List<E.ServiceResource>>(), true))
                        .ReturnsAsync((List<E.ServiceResource>)null!);

        Func<Task> act = async () => await _service.CreateAsync(request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resources not assigned");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task DeleteAsync_ShouldReturnTrue_WhenFound(
        long id,
        E.ServiceResource entity
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id)).ReturnsAsync(entity);
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());

        var result = await _service.DeleteAsync(id);

        result.Should().BeTrue();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task DeleteAsync_ShouldThrow_WhenNotFound(long id)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id)).ReturnsAsync((E.ServiceResource?)null);

        Func<Task> act = async () => await _service.DeleteAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource assignation not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetAllByResourceIdAsync_ShouldReturnList(
        long resourceId,
        List<E.ServiceResource> entities,
        ICollection<ResponseServiceResourceDto> response
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().ListAsync(It.IsAny<BaseSpecification<E.ServiceResource>>()))
                        .ReturnsAsync(entities);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ICollection<ResponseServiceResourceDto>>(entities)).Returns(response);

        var result = await _service.GetAllByResourceIdAsync(resourceId);

        result.Should().BeEquivalentTo(response);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldReturn_ResponseDto(
        long id,
        E.ServiceResource entity,
        ResponseServiceResourceDto response
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id)).ReturnsAsync(entity);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseServiceResourceDto>(entity)).Returns(response);

        var result = await _service.GetByIdAsync(id);

        result.Should().BeEquivalentTo(response);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldThrow_WhenNotFound(long id)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id)).ReturnsAsync((E.ServiceResource?)null);

        Func<Task> act = async () => await _service.GetByIdAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource assignation not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldReturn_ResponseDto(
        long id,
        RequestServiceResourceDto request,
        E.ServiceResource entity,
        ResponseServiceResourceDto response
    )
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.AutoMapper.Map<E.ServiceResource>(request)).Returns(entity);
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().Update(entity, true));
        _mockCoreService.Setup(m => m.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().GetByIdAsync(id)).ReturnsAsync(entity);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseServiceResourceDto>(entity)).Returns(response);

        var result = await _service.UpdateAsync(id, request);

        result.Should().BeEquivalentTo(response);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldThrow_WhenNotFound(long id, RequestServiceResourceDto request)
    {
        _mockCoreService.Setup(m => m.UnitOfWork.Repository<E.ServiceResource>().ExistsAsync(id)).ReturnsAsync(false);

        Func<Task> act = async () => await _service.UpdateAsync(id, request);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Resource assignation not found");
    }
}
