using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceService
{
    /// <summary>
    /// Get all services
    /// </summary>
    /// <returns>List of services</returns>
    Task<ICollection<ResponseServiceDto>> GetAllAsync();

    /// <summary>
    /// Get service by id
    /// </summary>
    /// <param name="id">Id of the service</param>
    /// <returns>Service</returns>
    Task<ResponseServiceDto> GetByIdAsync(long id);

    /// <summary>
    /// Create a new service
    /// </summary>
    /// <param name="request">Service request</param>
    /// <returns>Created service</returns>
    Task<ResponseServiceDto> CreateAsync(RequestServiceDto request);

    /// <summary>
    /// Update an existing service
    /// </summary>
    /// <param name="id">Id of the service</param>
    /// <param name="request">Service request</param>
    /// <returns>Created service</returns>
    Task<ResponseServiceDto> UpdateAsync(long id, RequestServiceDto request);

    /// <summary>
    /// Delete a service 
    /// </summary>
    /// <param name="id">Id of the service</param>
    /// <returns>True if the service was deleted successfully, false otherwise</returns>
    Task<bool> DeleteAsync(long id);
}