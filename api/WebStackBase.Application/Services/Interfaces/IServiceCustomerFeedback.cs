using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceCustomerFeedback
{

    /// <summary>
    /// Get all customer feedbacks
    /// </summary>
    /// <returns>List of customer feedbacks</returns>
    Task<ICollection<ResponseCustomerFeedbackDto>> GetAllAsync();

    /// <summary>
    /// Get customer feedback by id
    /// </summary>
    /// <param name="id">Id of the customer feedback</param>
    /// <returns>Customer feedback</returns>
    Task<ResponseCustomerFeedbackDto> GetByIdAsync(long id);

    /// <summary>
    /// Create a new customer feedback
    /// </summary>
    /// <param name="request">Customer feedback request</param>
    /// <returns>Created customer feedback</returns>
    Task<ResponseCustomerFeedbackDto> CreateAsync(RequestCustomerFeedbackDto request);

    /// <summary>
    /// Update an existing customer feedback
    /// </summary>
    /// <param name="id">Id of the customer feedback</param>
    /// <param name="request">Customer feedback request</param>
    /// <returns>Created customer feedback</returns>
    Task<ResponseCustomerFeedbackDto> UpdateAsync(long id, RequestCustomerFeedbackDto request);

    /// <summary>
    /// Delete a customer feedback 
    /// </summary>
    /// <param name="id">Id of the customer feedback</param>
    /// <returns>True if the customer feedback was deleted successfully, false otherwise</returns>
    Task<bool> DeleteAsync(long id);
}