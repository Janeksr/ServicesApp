using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models.User;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class RoleRepository : GenericRepository<UserManager<Client>>, IRoleRepository
    {
        private readonly UserManager<Client> userManager;
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailSender emailSender;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RoleRepository(ApplicationDbContext context, UserManager<Client> userManager, 
            IMapper mapper, RoleManager<IdentityRole> roleManager, IEmailSender emailSender, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task ChangeUserRole(string newRole)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var userActualRole = await FindUserRole(user);
            await userManager.RemoveFromRoleAsync(user, userActualRole.Role);
            await userManager.AddToRoleAsync(user, newRole);
        }

        public async Task<UserVM> FindUserRole(Client user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var userVM = mapper.Map<UserVM>(user);
            userVM.Role = roles[0];
            return userVM;
        }

        public async Task<UserVM> UpdateUserRole(UserRoleVM userRole)
        {
            var user = await userManager.FindByEmailAsync(userRole.Email);
            var userActualRole = await FindUserRole(user);
            await userManager.RemoveFromRoleAsync(user, userActualRole.Role);
            await userManager.AddToRoleAsync(user, userRole.NewRole);
            var userVM = await UserRoleDetail(user);

            if(userRole.NewRole == Roles.Company)
            {
                await emailSender.SendEmailAsync(userRole.Email, "Company Account", "<a href='https://localhost:7030/'>Add your company.</a>");
            }

            return userVM;
        }

        public async Task<UserVM> UserRoleDetail(Client user)
        {
            var userVM = await FindUserRole(user);
            userVM.AllRoles = new SelectList(roleManager.Roles, "Name", "Name");
            userVM.UserRole = new UserRoleVM
            {
                Email = user.Email
            };
            return userVM;
        }


    }
}
