using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class RoleController : Controller
    {
        private readonly IRoleRepository roleRepository;
        private readonly UserManager<Client> userManager;

        public RoleController(IRoleRepository roleRepository, UserManager<Client> userManager)
        {
            this.roleRepository = roleRepository;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FindUser(UserVM userVM)
        {
            var user = await userManager.FindByEmailAsync(userVM.Email);

            if (user == null)
            {
                ModelState.AddModelError(nameof(userVM.Email), "Email not found or matched");
                return View(nameof(Index), userVM);
            }
            var model = await roleRepository.UserRoleDetail(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserRole(UserRoleVM userRole)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = await roleRepository.UpdateUserRole(userRole);
                    return View(nameof(FindUser), model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An Error Has Occured. Please Try Again Later");
            }
            return View(nameof(Index));
        }
    }
}
