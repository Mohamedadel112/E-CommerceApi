using Dashboard.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class UserController(UserManager<User>user,RoleManager<IdentityRole>role) : Controller
    {
        private readonly UserManager<User> _user = user;
        private readonly RoleManager<IdentityRole> _role = role;

        public async Task<IActionResult> Index()
        {
            var users = await _user.Users.Select(u => new UserVM()
            {
                Id = u.Id,
                DisplayName = u.DisplayName,
                Email = u.Email,
                phonenumber = u.PhoneNumber,
                Username = u.UserName,
                roles = _user.GetRolesAsync(u).Result,
            }).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _user.FindByIdAsync(id);
            var roles = await _role.Roles.ToListAsync();
            var viewmodel = new UserRoleVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(r => new RoleEditVM()
                {
                    Id = r.Id,
                    Name = r.Name,
                    IsSelected = _user.IsInRoleAsync(user, r.Name).Result
                }).ToList()

              
            };

            return View(viewmodel);
        }


        [HttpPost]
        public async Task<IActionResult>Edit(string id , UserRoleVM userRoleVM)
        {
            var user = await _user.FindByIdAsync(userRoleVM.Id);
            var userrole = await _user.GetRolesAsync(user);
            foreach (var role in userRoleVM.Roles)
            {
                if (userrole.Any(r => r == role.Name) && !role.IsSelected)
                    await _user.RemoveFromRoleAsync(user, role.Name);
                if (!userrole.Any(r => r == role.Name) && role.IsSelected)
                    await _user.AddToRoleAsync(user, role.Name);
            }
            return RedirectToAction(nameof(Index));
        }






    }
}
