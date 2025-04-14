using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceReservation
{
    /// <summary>
    /// Get all reservations
    /// </summary>
    /// <returns>List of reservations</returns>
    Task<ICollection<ResponseReservationDto>> GetAllAsync();

    /// <summary>
    /// Get reservation by id
    /// </summary>
    /// <param name="id">Id of the reservation</param>
    /// <returns>Reservation</returns>
    Task<ResponseReservationDto> GetByIdAsync(long id);

    /// <summary>
    /// Create a new reservation
    /// </summary>
    /// <param name="request">Reservation request</param>
    /// <returns>Created reservation</returns>
    Task<ResponseReservationDto> CreateAsync(RequestReservationDto request);

    /// <summary>
    /// Update an existing reservation
    /// </summary>
    /// <param name="id">Id of the reservation</param>
    /// <param name="request">Reservation request</param>
    /// <returns>Created reservation</returns>
    Task<ResponseReservationDto> UpdateAsync(long id, RequestReservationDto request);

    /// <summary>
    /// Delete a reservation 
    /// </summary>
    /// <param name="id">Id of the reservation</param>
    /// <returns>True if the reservation was deleted successfully, false otherwise</returns>
    Task<bool> DeleteAsync(long id);
}