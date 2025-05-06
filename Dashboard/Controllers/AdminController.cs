using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace Dashboard.Controllers
{
    public class AdminController(UserManager<User> user, SignInManager<User> signIn ) : Controller
    {
        private readonly UserManager<User> _user = user;
        private readonly SignInManager<User> _signIn = signIn;
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginDTO loginDTO)
        {
            var user = await _user.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email Invalid");
                return RedirectToAction(nameof(login));
            }
            var result = await _signIn.CheckPasswordSignInAsync(user, loginDTO.Password,false);
            if (!result.Succeeded||!await  _user.IsInRoleAsync(user,"Admin") )
            {
                ModelState.AddModelError("", "You are Not Authorize");
                return RedirectToAction(nameof(login));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> logout()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction(nameof(login));
        }

    }
}
