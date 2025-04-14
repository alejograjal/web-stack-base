

using System.Linq.Expressions;
using WebStackBase.Domain.Core.Models;
using Microsoft.EntityFrameworkCore.Query;
using WebStackBase.Application.Core.Models;
using WebStackBase.Domain.Core.Specifications;

namespace WebStackBase.Application.Core.Interfaces;

public interface IBaseRepositoryAsync<T> where T : BaseSimpleEntity
{
    IQueryable<T> AsQueryable(params Expression<Func<T, object>>[]? includes);

    IQueryable<T> AsQueryable(ISpecification<T>? spec = null, params Expression<Func<T, object>>[]? includes);

    Task<IList<T>> FromSqlAsync(FormattableString sql);

    Task<bool> ExistsAsync(long id);

    Task<T?> GetByIdAsync(long id);

    Task<T?> GetByIdWithExpressionsAsync(long id, params Expression<Func<T, object>>[]? includes);

    Task<T?> GetByIdWithStringIncludesAsync(long id, params string[]? includes);

    Task<T?> GetByIdWithNoTrackingAsync(long id, bool forceNoTracking = false, params string[] includes);

    Task<IList<T>> ListAllAsync();

    Task<IList<T>> ListAllAsync(params Expression<Func<T, object>>[] includes);

    Task<IList<T>> ListAllAsync(params string[] includes);

    Task<IList<T>> ListAsync(ISpecification<T> spec);

    Task<IList<T>> ListAsync(ISpecification<T> spec, params Expression<Func<T, object>>[] includes);

    Task<IList<T>> ListAsync(ISpecification<T> spec, params string[] includes);

    Task<IList<TResult>> ListAsync<Tkey, TResult>(ISpecification<T> spec, Expression<Func<T, Tkey>> grouping, Expression<Func<IGrouping<Tkey, T>, TResult>> resultSelector);

    Task<IList<TResult>> ListAsync<Tkey, TResult>(IQueryable<T> query, Expression<Func<T, Tkey>> grouping, Expression<Func<IGrouping<Tkey, T>, TResult>> resultSelector, params Expression<Func<T, object>>[] includes);

    Task<IList<T>> ListAsync(IQueryable<T> query);

    Task<IList<T>> ListAsync(IQueryable<T> query, params string[]? includes);

    Task<IList<T>> ListAsync(IQueryable<T> query, params Expression<Func<T, object>>[]? includes);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, params string[]? includes);

    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, params Expression<Func<T, object>>[]? includes);

    Task<T?> FirstOrDefaultAsync(IQueryable<T> query);

    Task<T?> FirstOrDefaultAsync(IQueryable<T> query, params Expression<Func<T, object>>[]? includes);

    Task<T?> FirstOrDefaultAsync(IQueryable<T> query, params string[]? includes);

    Task<TResult?> FirstOrDefaultAsync<Tkey, TResult>(IQueryable<T> query, Expression<Func<T, Tkey>> grouping, Expression<Func<IGrouping<Tkey, T>, TResult>> resultSelector, params Expression<Func<T, object>>[]? includes);

    Task<T> AddAsync(T entity, bool disableTracking = true);

    Task<IList<T>> AddRangeAsync(IList<T> entities, bool disableTracking = true);

    void Update(T entity, bool disableTracking = true);

    Task<int> ExecuteDeleteAsync(ISpecification<T> spec);

    Task<int> ExecuteUpdateAsync(Expression<Func<T, bool>> query, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> expression);

    Task<int> ExecuteUpdateAsync(long id, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> expression);

    void Delete(T entity, bool disableTracking = true);

    void Delete(long id, bool disableTracking = true);

    IList<T> Delete(IList<T> entities, bool disableTracking = true);

    void RemoveRange(IList<T> collection);

    PageResultDto<T> GetPageResult(IQueryable<T> query, PagingDetails pagingDetails);

    PageResultDto<T> GetPageResult(IEnumerable<T> data, PagingDetails pagingDetails);

    Task<int> CountAsync(ISpecification<T> spec);

    void IgnoreField(T entity, Expression<Func<T, object>> field);
}