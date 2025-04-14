using AutoMapper;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.ResponseDTOs;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.ResponseDTOs.Enums;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceUser(ICoreService<User> coreService) : IServiceUser
{
    private readonly string[] UserWithRole = ["RoleIdNavigation"];

    /// <inheritdoc />
    public async Task<ResponseUserDto> FindByIdAsync(long id)
    {
        var spec = new BaseSpecification<User>(x => x.Id == id);
        var user = await coreService.UnitOfWork.Repository<User>().FirstOrDefaultAsync(spec, UserWithRole);
        if (user == null) throw new NotFoundException("User not found.");

        return coreService.AutoMapper.Map<ResponseUserDto>(user);
    }

    /// <inheritdoc />
    public async Task<ResponseUserDto> FindByEmailAsync(string email)
    {
        var spec = new BaseSpecification<User>(x => x.Email == email);
        var user = await coreService.UnitOfWork.Repository<User>().FirstOrDefaultAsync(spec);
        if (user == null) throw new NotFoundException("Usuario not found.");

        return coreService.AutoMapper.Map<ResponseUserDto>(user);
    }

    /// <inheritdoc />
    public async Task<ICollection<ResponseUserDto>> ListAllAsync(string? role = null)
    {
        if (role == null)
        {
            var list = await coreService.UnitOfWork.Repository<User>().ListAllAsync();
            return coreService.AutoMapper.Map<ICollection<ResponseUserDto>>(list);
        }

        RoleApplication roleEnum;
        if (!Enum.TryParse(role, out roleEnum)) throw new WebStackBaseException("Role not found.");

        var spec = new BaseSpecification<User>(x => x.RoleId == (long)roleEnum);
        var listFilter = await coreService.UnitOfWork.Repository<User>().ListAsync(spec);
        var collection = coreService.AutoMapper.Map<ICollection<ResponseUserDto>>(listFilter);

        return collection;
    }

    /// <inheritdoc />
    public async Task<bool> ExistsUserAsync(long id)
    {
        return await coreService.UnitOfWork.Repository<User>().ExistsAsync(id);
    }

    /// <inheritdoc />
    public async Task<ResponseUserDto> LoginAsync(string email, string password)
    {
        var spec = new BaseSpecification<User>(x => x.Email == email && x.Password == password);
        var user = await coreService.UnitOfWork.Repository<User>().FirstOrDefaultAsync(spec, UserWithRole);
        if (user == null) throw new NotFoundException("Email or password incorrect.");

        return coreService.AutoMapper.Map<ResponseUserDto>(user);
    }
}