using Identity.Models;
using Identity.Models.ViewModels;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IIdentityServerInteractionService interactionService;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IIdentityServerInteractionService interactionService) =>
            (this.signInManager,this.userManager,this.interactionService) = (signInManager,userManager, interactionService);

        [HttpGet]
        [Route("[action]")]
        public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl});

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel); 
            }

            var user = await userManager.FindByNameAsync(viewModel.UserName);
            if (user == null) 
            {
                ModelState.AddModelError(string.Empty,"User not found");
                return View(viewModel);
            }

            var result = await signInManager.PasswordSignInAsync(
                userName:viewModel.UserName, 
                password: viewModel.Password, 
                isPersistent:false, 
                lockoutOnFailure:false);
            if (result.Succeeded) 
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login Error");
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl) => View(new RegisterViewModel {ReturnUrl = returnUrl });

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new User()
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email
            };

            var result = await userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user,false);
                return Redirect("https://localhost:44347/");
            }
            ModelState.AddModelError(string.Empty, "Register Error");
            return View(viewModel);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var logout = await interactionService.GetLogoutContextAsync(logoutId);
            await signInManager.SignOutAsync();
            return Redirect(logout.PostLogoutRedirectUri);
        }

    }
}
