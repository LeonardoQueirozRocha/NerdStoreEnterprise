using FluentValidation.Results;
using NSE.Identity.API.Models;

namespace NSE.Identity.API.Services.Interfaces;

public interface IAuthService
{
    Task<ValidationResult> CreateUserAsync(UserRegistration userRegistration);
    Task<UserResponseLogin> GenerateJwtAsync(string email);
    Task<ValidationResult> LoginAsync(UserLogin userLogin);
    Task<RefreshToken> GetRefreshTokenAsync(Guid token);
}
