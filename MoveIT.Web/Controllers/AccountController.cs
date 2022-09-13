using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoveIT.Application.DTOs;
using MoveIT.Application.Enums;
using MoveIT.Services.Interfaces;
using MoveIT.Web.Models;

namespace MoveIT.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: AccountController
        public ActionResult Login(string returnUrl)
        {
            var loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(loginViewModel);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var authDto = model.Adapt<AuthDto>();
            var loginResult = await _accountService.AuthenticateAsync(authDto);

            if (loginResult == LoginResult.Succeeded)
                return Redirect(model.ReturnUrl ?? "/");

            ModelState.AddModelError("", "Login failed, wrong credentials ");

            return View(model);
        }

        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _accountService.SignOutAsync();

            return Redirect("/");
        }

    }
}
