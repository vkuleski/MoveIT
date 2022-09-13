using MoveIT.Application.DTOs;
using MoveIT.Application.Enums;

namespace MoveIT.Services.Interfaces;

public interface IAccountService
{
    Task<LoginResult> AuthenticateAsync(AuthDto auth);
    Task SignOutAsync();
}