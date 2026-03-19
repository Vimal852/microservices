using Application.DTOs;
using Application.Interfaces;
using Domain.Enum;
using Domain.Modal;
using Microsoft.Extensions.Configuration;

namespace Application.Services;

public class AuthService(
    IUserRepository userRepo,
    ITokenService tokenService,
    IConfiguration config) : IAuthService
{
    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var existing = await userRepo.GetByEmailAsync(request.Email);
        if (existing is not null)
            throw new InvalidOperationException("Email already registered.");

        var enterpriseExists = await userRepo.GetCompnayBYid(request.CompanyId);

        var role = Enum.TryParse<UserRole>(request.Role, true, out var parsedRole)
            ? parsedRole : UserRole.User;

        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email.ToLower(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            CompanyId = request.CompanyId,  // 
            Role = role
        };

        await userRepo.AddAsync(user);
        await userRepo.SaveChangesAsync();

        return await IssueTokensAsync(user);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await userRepo.GetByEmailAsync(request.Email.ToLower())
            ?? throw new UnauthorizedAccessException("Invalid credentials.");

        if (!user.IsActive)
            throw new UnauthorizedAccessException("Account is deactivated.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials.");

        return await IssueTokensAsync(user);
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
    {
        var user = await userRepo.GetByRefreshTokenAsync(refreshToken)
            ?? throw new UnauthorizedAccessException("Invalid refresh token.");

        var existingToken = user.RefreshTokens
            .Single(t => t.Token == refreshToken);

        if (!existingToken.IsActive)
            throw new UnauthorizedAccessException("Refresh token expired or revoked.");

        // Rotate: purana revoke karo, naya do
        existingToken.IsRevoked = true;
        existingToken.ReplacedByToken = tokenService.GenerateRefreshToken();

        var newRefresh = new RefreshToken
        {
            Token = existingToken.ReplacedByToken,
            ExpiresAt = DateTime.UtcNow.AddDays(
                double.Parse(config["Jwt:RefreshTokenExpiryDays"]!)),
            UserId = user.Id
        };

        user.RefreshTokens.Add(newRefresh);
        await userRepo.UpdateAsync(user);
        await userRepo.SaveChangesAsync();

        var accessToken = tokenService.GenerateAccessToken(user);
        return BuildResponse(accessToken, newRefresh, user);
    }

    public async Task RevokeTokenAsync(string refreshToken)
    {
        var user = await userRepo.GetByRefreshTokenAsync(refreshToken)
            ?? throw new UnauthorizedAccessException("Invalid token.");

        var token = user.RefreshTokens.Single(t => t.Token == refreshToken);
        if (!token.IsActive)
            throw new InvalidOperationException("Token already revoked.");

        token.IsRevoked = true;
        await userRepo.UpdateAsync(user);
        await userRepo.SaveChangesAsync();
    }

    // ---------- private helpers ----------

    private async Task<AuthResponse> IssueTokensAsync(User user)
    {
        var accessToken = tokenService.GenerateAccessToken(user);
        var refreshToken = new RefreshToken
        {
            Token = tokenService.GenerateRefreshToken(),
            ExpiresAt = DateTime.UtcNow.AddDays(
                double.Parse(config["Jwt:RefreshTokenExpiryDays"]!)),
            UserId = user.Id
        };

        user.RefreshTokens.Add(refreshToken);
   
        return BuildResponse(accessToken, refreshToken, user);
    }

    private static AuthResponse BuildResponse(
        string accessToken, RefreshToken refresh, User user) =>
        new(
            accessToken,
            refresh.Token,
            refresh.ExpiresAt,
            new UserDto(user.Id, user.FullName, user.Email, user.Role.ToString())
        );
}