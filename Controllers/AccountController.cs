/*using System;
using System.Threading.Tasks;
using BookManagement.Model;
using BookManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<JwtAuthenticationManager> _userManager;

        private readonly SignInManager<JwtAuthenticationManager> _signInManager;
        public AccountController(
            UserManager<JwtAuthenticationManager> userManager,
            SignInManager<JwtAuthenticationManager> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid) return Ok();
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Login Failed, Please Check Your Details");
                    return Ok();
                }
                return LocalRedirect("~/");

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return Ok();
            }

        }

        public IActionResult Register()
        {
            return Ok();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                JwtAuthenticationManager user = await _userManager.FindByEmailAsync(model.Email);

                if (user is null)
                {
                    user = new JwtAuthenticationManager
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = model.Password
                    };

                    var result = await _userManager.CreateAsync(user, model.ConfirmPassword);

                    if (!result.Succeeded)
                    {
                        return Ok();
                    }
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Login");
            }
            return Ok();
        }
        
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("~/");
        }
    }
}*/