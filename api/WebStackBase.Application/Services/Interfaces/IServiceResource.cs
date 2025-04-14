using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceResource
{
    /// <summary>
    /// Get all resources
    /// </summary>
    /// <param name="onlyEnabled">
    /// If true, only enabled resources will be returned
    /// </param>
    /// <returns>List of resources</returns>
    Task<ICollection<ResponseResourceDto>> GetAllAsync(bool onlyEnabled = true);

    /// <summary>
    /// Get resource by id
    /// </summary>
    /// <param name="id">Id of the resource</param>
    /// <returns>Resource</returns>
    Task<ResponseResourceDto> GetByIdAsync(long id);

    /// <summary>
    /// Create a new resource
    /// </summary>
    /// <param name="request">Resource request</param>
    /// <returns>Created resource</returns>
    Task<ResponseResourceDto> CreateAsync(RequestResourceDto request);

    /// <summary>
    /// Update an existing resource
    /// </summary>
    /// <param name="id">Id of the resource</param>
    /// <param name="request">Resource request</param>
    /// <returns>Created resource</returns>
    Task<ResponseResourceDto> UpdateAsync(long id, RequestResourceDto request);

    /// <summary>
    /// Delete a resource 
    /// </summary>
    /// <param name="id">Id of the resource</param>
    /// <returns>True if the resource was deleted successfully, false otherwise</returns>
    Task<bool> DeleteAsync(long id);
}