using Microsoft.AspNetCore.Identity;
using MoveIT.Application.DTOs;
using MoveIT.Application.Enums;
using MoveIT.Data.Entities;
using MoveIT.Services.Interfaces;

namespace MoveIT.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<LoginResult> AuthenticateAsync(AuthDto auth)
    {
        var appUser = await _userManager.FindByEmailAsync(auth.Email);

        if (appUser == null)
            return LoginResult.Failed;

        SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, auth.Password, false, false);

        return signInResult.Succeeded
            ? LoginResult.Succeeded 
            : LoginResult.Failed;
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}