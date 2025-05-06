using Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class RoleController(RoleManager<IdentityRole> role) : Controller
    {
        private readonly RoleManager<IdentityRole> _role = role;

        public async Task<IActionResult> Index()
        {
           List<IdentityRole> roles = await _role.Roles.ToListAsync();
            return View(roles);
        }


        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                var RoleExist = await _role.RoleExistsAsync(roleVM.Name);
                if (!RoleExist)
                {
                    await _role.CreateAsync(new IdentityRole(roleVM.Name.Trim()));
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Name", "This Name is already exist");
                }
            }

            // في حال فشل التحقق، أعد تحميل قائمة الأدوار
            var roles = await _role.Roles.ToListAsync();
            ViewBag.Roles = roles;
            return View("Index");
        }



        public async Task<IActionResult>Delete(string id)
        {
            var role =await _role.FindByIdAsync(id);
            await _role.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _role.FindByIdAsync(id);

            var Mapping = new RoleEditVM() 
            {
               Name = role.Name
            };

            return View(Mapping);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,RoleEditVM roleEdit)
        {
            if (ModelState.IsValid)
            {
                var roleExist = await _role.RoleExistsAsync(roleEdit.Name);
                if (!roleExist)
                {
                  var role=  await _role.FindByIdAsync(roleEdit.Id);
                    role.Name = roleEdit.Name;
                    await _role.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));

        }














    }
}
