using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs;

public record AuthResponse(
    string AccessToken,
    string RefreshToken,
    DateTime AccessTokenExpiry,
    UserDto User
);

public record UserDto(
    Guid Id,
    string FullName,
    string Email,
    string Role
);

public record RefreshTokenRequest(string RefreshToken);
