using Dapper;
using System.Data;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using WebStackBase.Common.Extensions;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Domain.Core.Models;
using WebStackBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using WebStackBase.Application.Core.Interfaces;

namespace WebStackBase.Infrastructure.Repositories;

public class UnitOfWork(ILoggerFactory loggerFactory, WebStackBaseContext dbContext) : IUnitOfWork
{
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    private readonly WebStackBaseContext _dbContext = dbContext;

    private readonly ConcurrentDictionary<Type, object> _repositories = new();

    public IDbConnection SqlConnection => new SqlConnection(_dbContext.Connection.ConnectionString);

    public IDbContextTransaction BeginTransaction() => _dbContext.Database.BeginTransaction();

    public async Task<IDbContextTransaction> BeginTransactionAsync() => await _dbContext.Database.BeginTransactionAsync();

    public void ClearChangeTracking() => _dbContext.ChangeTracker.Clear();

    public IExecutionStrategy CreateExecutionStrategy() => _dbContext.Database.CreateExecutionStrategy();

    public async Task<IList<T>?> FromSqlAsync<T>(FormattableString sql, params Expression<Func<T, object>>[]? includes)
    {
        using var connection = new SqlConnection(_dbContext.Database.GetConnectionString());
        await connection.OpenAsync();
        var result = await connection.QueryAsync<T>(sql.GetSQL(), new { });
        return result.ToList();
    }

    public async Task<IList<string>> GetTableColumnsAsync(string tableName) => await GetTableColumnsAsync(tableName, excludeColumnsList: null!);

    public async Task<IList<string>> GetTableColumnsAsync(string tableName, string excludeColumn) => await GetTableColumnsAsync(tableName, new List<string>() { excludeColumn });

    public async Task<IList<string>> GetTableColumnsAsync(string tableName, List<string> excludeColumnsList)
    {
        FormattableString sqlExclude;
        sqlExclude = $"1=1";

        if (!Regex.IsMatch(tableName, @"^[a-zA-Z0-9_]+$", RegexOptions.None, TimeSpan.FromMilliseconds(100)))
        {
            throw new ArgumentException("El nombre de la tabla contiene caracteres no permitidos.");
        }

        if (excludeColumnsList != null && excludeColumnsList.HasItems())
        {
            sqlExclude = FormattableStringFactory.Create("Name NOT IN({0})", string.Join(".", excludeColumnsList.Select(m => "'" + m + "'")));
        }

        var sql = FormattableStringFactory.Create(
            "SELECT Name FROM sys.columns WHERE OBJECT_NAME(OBJECT_ID) = '{0}s' AND is_hidden = 0 AND {1}", tableName, sqlExclude.GetSQL()
        );

        var columns = await FromSqlAsync<string>(sql);
        return columns!;
    }

    public async Task<int> GetTotalRowCountAsync(FormattableString sql)
    {
        using var connection = new SqlConnection(_dbContext.Database.GetConnectionString());
        await connection.OpenAsync();
        var result = await connection.QueryFirstAsync<int>(sql.GetSQL(), new { });
        return result;
    }

    public IBaseRepositoryAsync<T> Repository<T>() where T : BaseSimpleEntity
    {
        var entityType = typeof(T);

        var repositoryLazy = (Lazy<IBaseRepositoryAsync<T>>)_repositories.GetOrAdd(entityType, type => new Lazy<IBaseRepositoryAsync<T>>(() =>
        {
            var repositoryType = typeof(BaseRepositoryAsync<>);
            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(type), _loggerFactory, _dbContext);
            return (IBaseRepositoryAsync<T>)repository!;
        }));

        return repositoryLazy.Value;
    }

    public async Task RollbackChangesAsync() => await _dbContext.Database.RollbackTransactionAsync();

    public async Task<int> SaveChangesAsync()
    {
        int rowsAffected = await _dbContext.SaveChangesAsync();
        if (rowsAffected == 0) throw new WebStackBaseException("Proceso no se ha podido completar.");

        return rowsAffected;
    }
}