using System.Data;
using System.Linq.Expressions;
using WebStackBase.Domain.Core.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebStackBase.Application.Core.Interfaces;

public interface IUnitOfWork
{
    IDbConnection SqlConnection { get; }

    IBaseRepositoryAsync<T> Repository<T>() where T : BaseSimpleEntity;

    IExecutionStrategy CreateExecutionStrategy();

    IDbContextTransaction BeginTransaction();

    Task<IDbContextTransaction> BeginTransactionAsync();

    Task<int> SaveChangesAsync();

    Task RollbackChangesAsync();

    void ClearChangeTracking();

    Task<IList<T>?> FromSqlAsync<T>(FormattableString sql, params Expression<Func<T, object>>[]? includes);

    Task<int> GetTotalRowCountAsync(FormattableString sql);

    Task<IList<string>> GetTableColumnsAsync(string tableName);

    Task<IList<string>> GetTableColumnsAsync(string tableName, string excludeColumn);

    Task<IList<string>> GetTableColumnsAsync(string tableName, List<string> excludeColumnsList);
}