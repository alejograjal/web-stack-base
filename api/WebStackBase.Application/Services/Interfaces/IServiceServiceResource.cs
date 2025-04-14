using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceServiceResource
{
    /// <summary>
    /// Get all service resources
    /// </summary>
    /// <param name="resourceId">Id of the resource</param>
    /// <returns>List of service resources</returns>
    Task<ICollection<ResponseServiceResourceDto>> GetAllByResourceIdAsync(long resourceId);

    /// <summary>
    /// Get service resource by id
    /// </summary>
    /// <param name="id">Id of the service resource</param>
    /// <returns>Service resource</returns>
    Task<ResponseServiceResourceDto> GetByIdAsync(long id);

    /// <summary>
    /// Create a new service resource
    /// </summary>
    /// <param name="request">Service resource request</param>
    /// <returns>Created service resource</returns>
    Task<ResponseServiceResourceDto> CreateAsync(RequestServiceResourceDto request);

    /// <summary>
    /// Create a new service resource
    /// </summary>
    /// <param name="request">List of service resource request</param>
    /// <returns>True if the service resource was created successfully, false otherwise</returns>
    Task<bool> CreateAsync(IEnumerable<RequestServiceResourceDto> request);

    /// <summary>
    /// Update an existing service resource
    /// </summary>
    /// <param name="id">Id of the service resource</param>
    /// <param name="request">Service resource request</param>
    /// <returns>Created service resource</returns>
    Task<ResponseServiceResourceDto> UpdateAsync(long id, RequestServiceResourceDto request);

    /// <summary>
    /// Delete a service resource 
    /// </summary>
    /// <param name="id">Id of the service resource</param>
    /// <returns>True if the service resource was deleted successfully, false otherwise</returns>
    Task<bool> DeleteAsync(long id);
}