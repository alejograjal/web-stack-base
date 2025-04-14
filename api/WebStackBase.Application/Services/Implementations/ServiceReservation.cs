using FluentValidation;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceReservation(ICoreService<Reservation> coreService, IValidator<Reservation> reservationValidator) : IServiceReservation
{
    /// <inheritdoc />
    public async Task<ResponseReservationDto> CreateAsync(RequestReservationDto request)
    {
        var reservation = await ValidateReservationAsync(request);

        var result = await coreService.UnitOfWork.Repository<Reservation>().AddAsync(reservation);
        await coreService.UnitOfWork.SaveChangesAsync();

        if (result == null) throw new NotFoundException("Reservation not saved");

        return coreService.AutoMapper.Map<ResponseReservationDto>(result);
    }

    /// <inheritdoc />
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseReservationDto>> GetAllAsync()
    {
        var list = await coreService.UnitOfWork.Repository<Reservation>().ListAllAsync();

        return coreService.AutoMapper.Map<ICollection<ResponseReservationDto>>(list);
    }

    /// <inheritdoc />
    public async Task<ResponseReservationDto> GetByIdAsync(long id)
    {
        var spec = new BaseSpecification<Reservation>(x => x.Id == id);
        var branch = await coreService.UnitOfWork.Repository<Reservation>().FirstOrDefaultAsync(spec);
        if (branch == null) throw new NotFoundException("Reservation not found");

        return coreService.AutoMapper.Map<ResponseReservationDto>(branch);
    }

    /// <inheritdoc />
    public async Task<ResponseReservationDto> UpdateAsync(long id, RequestReservationDto request)
    {
        if (!await coreService.UnitOfWork.Repository<Reservation>().ExistsAsync(id)) throw new NotFoundException("Reservation not found");

        var reservation = await ValidateReservationAsync(request, id);

        coreService.UnitOfWork.Repository<Reservation>().Update(reservation);
        await coreService.UnitOfWork.SaveChangesAsync();

        return await GetByIdAsync(id);
    }

    private async Task<Reservation> ValidateReservationAsync(RequestReservationDto requestReservationDto, long id = 0)
    {
        var reservation = coreService.AutoMapper.Map<Reservation>(requestReservationDto);

        await reservationValidator.ValidateAndThrowAsync(reservation);
        reservation.Id = id;

        return reservation;
    }
}