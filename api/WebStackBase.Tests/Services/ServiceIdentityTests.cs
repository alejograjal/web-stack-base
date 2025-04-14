using Moq;
using AutoFixture;
using FluentAssertions;
using WebStackBase.Util;
using AutoFixture.Xunit2;
using WebStackBase.Infrastructure;
using WebStackBase.Tests.Attributes;
using WebStackBase.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Domain.Core.Specifications;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;
using WebStackBase.Application.Services.Implementations;
using WebStackBase.Application.Configuration.Authentication;
using WebStackBase.Application.Dtos.Response.Authentication;

namespace WebStackBase.Tests.Services;

public class ServiceIdentityTests
{
    private readonly Mock<ICoreService<TokenMaster>> _mockCoreService;
    private readonly Mock<IServiceUser> _mockServiceUser;
    private readonly Mock<TokenValidationParameters> _mockTokenValidationParameters;
    private readonly ServiceIdentity _serviceIdentity;

    private Fixture fixture;

    public ServiceIdentityTests()
    {
        _mockCoreService = new Mock<ICoreService<TokenMaster>>();
        _mockServiceUser = new Mock<IServiceUser>();

        _mockTokenValidationParameters = new Mock<TokenValidationParameters>();

        _serviceIdentity = new ServiceIdentity(
            GetFakeAuthConfig(),
            _mockCoreService.Object,
            _mockServiceUser.Object,
            _mockTokenValidationParameters.Object
        );

        fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Theory]
    [RecursionSafeAutoData]
    public async Task LoginAsync_ShouldReturn_TokenModel_WhenCredentialsAreValid(
            RequestUserLoginDto loginDto,
            ResponseUserDto userResponse)
    {
        // Arrange
        _mockServiceUser.Setup(s => s.LoginAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(userResponse);
        _mockCoreService.Setup(c => c.UnitOfWork.Repository<TokenMaster>().AddAsync(It.IsAny<TokenMaster>(), true))
                       .ReturnsAsync(new TokenMaster());
        _mockCoreService.Setup(c => c.UnitOfWork.SaveChangesAsync());

        // Act
        var result = await _serviceIdentity.LoginAsync(loginDto);

        // Assert
        result.Token.Should().NotBeNullOrWhiteSpace();
        result.RefreshToken.Should().NotBeNullOrWhiteSpace();
        result.Token.Should().MatchRegex(@"^[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+\.[A-Za-z0-9-_]+$"); // JWT format
        result.RefreshToken.Should().MatchRegex(@"^[a-f0-9\-]{36}$");
        _mockServiceUser.Verify(s => s.LoginAsync(loginDto.Email, Hashing.HashMd5(loginDto.Password)), Times.Once);
        _mockCoreService.Verify(c => c.UnitOfWork.Repository<TokenMaster>().AddAsync(It.IsAny<TokenMaster>(), true), Times.Once);
    }

    [Theory]
    [AutoData]
    public async Task RefreshTokenAsync_ShouldThrow_Exception_WhenRefreshTokenIsInvalid(
        TokenModel tokenRequest)
    {
        // Arrange
        _mockCoreService.Setup(c => c.UnitOfWork.Repository<TokenMaster>().FirstOrDefaultAsync(It.IsAny<BaseSpecification<TokenMaster>>()))
                       .ReturnsAsync((TokenMaster)null); // Simulate invalid token

        // Act
        Func<Task> act = async () => await _serviceIdentity.RefreshTokenAsync(tokenRequest);

        // Assert
        await act.Should().ThrowAsync<WebStackBaseException>().WithMessage("Couldn't refresh token.");
    }

    private static AuthenticationConfiguration GetFakeAuthConfig() =>
        new AuthenticationConfiguration
        {
            JwtSettings_Secret = "ThisIsASecretKeyForTestsOnly!123456",
            JwtSettings_TokenLifetime = TimeSpan.FromMinutes(30)
        };
}