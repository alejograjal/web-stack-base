using Moq;
using FluentAssertions;
using WebStackBase.Infrastructure;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Tests.Attributes;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Dtos.Response.Enums;
using WebStackBase.Application.Services.Implementations;

namespace WebStackBase.Tests.Services;

public class ServiceUserTests
{
    private readonly Mock<ICoreService<User>> _mockCoreService;
    private readonly ServiceUser _service;

    public ServiceUserTests()
    {
        _mockCoreService = new Mock<ICoreService<User>>();
        _service = new ServiceUser(_mockCoreService.Object);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task FindByIdAsync_ShouldReturnDto_WhenUserExists(
        long id,
        User user,
        ResponseUserDto expected
    )
    {
        string[] UserWithRole = ["RoleIdNavigation"];
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<User>>(), UserWithRole))
                        .ReturnsAsync(user);
        _mockCoreService.Setup(x => x.AutoMapper.Map<ResponseUserDto>(user)).Returns(expected);

        var result = await _service.FindByIdAsync(id);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task FindByIdAsync_ShouldThrow_WhenUserNotFound(long id)
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<User>>()))
                        .ReturnsAsync((User?)null);

        Func<Task> act = async () => await _service.FindByIdAsync(id);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("User not found.");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task FindByEmailAsync_ShouldReturnDto_WhenUserExists(
        string email,
        User user,
        ResponseUserDto expected
    )
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<User>>()))
                        .ReturnsAsync(user);
        _mockCoreService.Setup(x => x.AutoMapper.Map<ResponseUserDto>(user)).Returns(expected);

        var result = await _service.FindByEmailAsync(email);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task FindByEmailAsync_ShouldThrow_WhenUserNotFound(string email)
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<User>>()))
                        .ReturnsAsync((User?)null);

        Func<Task> act = async () => await _service.FindByEmailAsync(email);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Usuario not found.");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task ListAllAsync_WithoutRole_ShouldReturnAllUsers(
        List<User> users,
        ICollection<ResponseUserDto> expected
    )
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().ListAllAsync()).ReturnsAsync(users);
        _mockCoreService.Setup(x => x.AutoMapper.Map<ICollection<ResponseUserDto>>(users)).Returns(expected);

        var result = await _service.ListAllAsync();

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task ListAllAsync_WithValidRole_ShouldReturnFilteredUsers(
        List<User> users,
        ICollection<ResponseUserDto> expected
    )
    {
        var role = RoleApplication.ADMINISTRADOR.ToString();

        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().ListAsync(It.IsAny<BaseSpecification<User>>())).ReturnsAsync(users);
        _mockCoreService.Setup(x => x.AutoMapper.Map<ICollection<ResponseUserDto>>(users)).Returns(expected);

        var result = await _service.ListAllAsync(role);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData("InvalidRoleName")]
    public async Task ListAllAsync_WithInvalidRole_ShouldThrow(string role)
    {
        Func<Task> act = async () => await _service.ListAllAsync(role);

        await act.Should().ThrowAsync<WebStackBaseException>().WithMessage("Role not found.");
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task ExistsUserAsync_ShouldReturnTrue_WhenExists(long id)
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().ExistsAsync(id)).ReturnsAsync(true);

        var result = await _service.ExistsUserAsync(id);

        result.Should().BeTrue();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task ExistsUserAsync_ShouldReturnFalse_WhenNotExists(long id)
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().ExistsAsync(id)).ReturnsAsync(false);

        var result = await _service.ExistsUserAsync(id);

        result.Should().BeFalse();
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task LoginAsync_ShouldReturnDto_WhenCorrectCredentials(
        string email,
        string password,
        User user,
        ResponseUserDto expected
    )
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<User>>(), It.IsAny<string[]>()))
                        .ReturnsAsync(user);
        _mockCoreService.Setup(x => x.AutoMapper.Map<ResponseUserDto>(user)).Returns(expected);

        var result = await _service.LoginAsync(email, password);

        result.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task LoginAsync_ShouldThrow_WhenInvalidCredentials(string email, string password)
    {
        _mockCoreService.Setup(x => x.UnitOfWork.Repository<User>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<User>>(), It.IsAny<string[]>()))
                        .ReturnsAsync((User?)null);

        Func<Task> act = async () => await _service.LoginAsync(email, password);

        await act.Should().ThrowAsync<NotFoundException>().WithMessage("Email or password incorrect.");
    }
}
