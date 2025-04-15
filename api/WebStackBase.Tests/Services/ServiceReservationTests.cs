using Moq;
using FluentAssertions;
using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Tests.Attributes;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Implementations;

namespace WebStackBase.Tests.Services;

public class ServiceReservationTests
{
    private readonly Mock<ICoreService<Reservation>> _mockCoreService;
    private readonly Mock<IValidator<Reservation>> _mockValidator;
    private readonly ServiceReservation _service;

    public ServiceReservationTests()
    {
        _mockCoreService = new Mock<ICoreService<Reservation>>();
        _mockValidator = new Mock<IValidator<Reservation>>();

        _service = new ServiceReservation(_mockCoreService.Object, _mockValidator.Object);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task CreateAsync_ShouldReturn_ReservationDto(
        RequestReservationDto requestDto,
        Reservation reservation,
        ResponseReservationDto responseDto
    )
    {
        _mockCoreService.Setup(m => m.AutoMapper.Map<Reservation>(requestDto)).Returns(reservation);
        _mockCoreService.Setup(r => r.UnitOfWork.Repository<Reservation>().AddAsync(reservation, true)).ReturnsAsync(reservation);
        _mockCoreService.Setup(r => r.UnitOfWork.SaveChangesAsync());
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseReservationDto>(reservation)).Returns(responseDto);

        // Act
        var result = await _service.CreateAsync(requestDto);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(r => r.UnitOfWork.Repository<Reservation>().AddAsync(reservation, true), Times.Once);
        _mockCoreService.Verify(r => r.UnitOfWork.SaveChangesAsync(), Times.Once);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetAllAsync_ShouldReturn_ReservationDtoList(
        IList<Reservation> reservationList,
        ICollection<ResponseReservationDto> responseDtoList
    )
    {
        _mockCoreService.Setup(r => r.UnitOfWork.Repository<Reservation>().ListAllAsync()).ReturnsAsync(reservationList);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ICollection<ResponseReservationDto>>(reservationList)).Returns(responseDtoList);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        result.Should().BeEquivalentTo(responseDtoList);
        _mockCoreService.Verify(r => r.UnitOfWork.Repository<Reservation>().ListAllAsync(), Times.Once);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldThrowNotFound_WhenNotFound(long id)
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Reservation>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Reservation>>()))
            .ReturnsAsync((Reservation)null!);

        // Act
        Func<Task> act = async () => await _service.GetByIdAsync(id);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Reservation not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task GetByIdAsync_ShouldReturn_ReservationDto(
        long id,
        Reservation reservation,
        ResponseReservationDto responseDto
    )
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Reservation>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Reservation>>()))
            .ReturnsAsync(reservation);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseReservationDto>(reservation)).Returns(responseDto);

        // Act
        var result = await _service.GetByIdAsync(id);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldThrowNotFound_WhenReservationNotExists(
        long id,
        RequestReservationDto request
    )
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Reservation>().ExistsAsync(id)).ReturnsAsync(false);

        // Act
        Func<Task> act = async () => await _service.UpdateAsync(id, request);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Reservation not found");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task UpdateAsync_ShouldReturn_UpdatedReservationDto(
        long id,
        RequestReservationDto request,
        Reservation reservation,
        ResponseReservationDto responseDto
    )
    {
        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Reservation>().ExistsAsync(id)).ReturnsAsync(true);
        _mockCoreService.Setup(m => m.AutoMapper.Map<Reservation>(request)).Returns(reservation);

        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Reservation>().Update(reservation, true));
        _mockCoreService.Setup(repo => repo.UnitOfWork.SaveChangesAsync());

        _mockCoreService.Setup(repo => repo.UnitOfWork.Repository<Reservation>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<Reservation>>()))
            .ReturnsAsync(reservation);
        _mockCoreService.Setup(m => m.AutoMapper.Map<ResponseReservationDto>(reservation)).Returns(responseDto);

        // Act
        var result = await _service.UpdateAsync(id, request);

        // Assert
        result.Should().BeEquivalentTo(responseDto);
        _mockCoreService.Verify(repo => repo.UnitOfWork.Repository<Reservation>().Update(reservation, true), Times.Once);
        _mockCoreService.Verify(repo => repo.UnitOfWork.SaveChangesAsync(), Times.Once);
    }
}