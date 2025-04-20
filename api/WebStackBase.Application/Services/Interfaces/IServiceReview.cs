using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceReview
{

    /// <summary>
    /// Get all customer feedbacks
    /// </summary>
    /// <returns>List of customer feedbacks</returns>
    Task<ICollection<ResponseReviewDto>> GetAllAsync();

    /// <summary>
    /// Get customer feedback by id
    /// </summary>
    /// <param name="id">Id of the customer feedback</param>
    /// <returns>Customer feedback</returns>
    Task<ResponseReviewDto> GetByIdAsync(long id);

    /// <summary>
    /// Create a new customer feedback
    /// </summary>
    /// <param name="request">Customer feedback request</param>
    /// <returns>Created customer feedback</returns>
    Task<ResponseReviewDto> CreateAsync(RequestReviewDto request);

    /// <summary>
    /// Update an existing customer feedback
    /// </summary>
    /// <param name="id">Id of the customer feedback</param>
    /// <param name="request">Customer feedback request</param>
    /// <returns>Created customer feedback</returns>
    Task<ResponseReviewDto> UpdateAsync(long id, RequestReviewDto request);

    /// <summary>
    /// Delete a customer feedback 
    /// </summary>
    /// <param name="id">Id of the customer feedback</param>
    /// <returns>True if the customer feedback was deleted successfully, false otherwise</returns>
    Task<bool> DeleteAsync(long id);
}