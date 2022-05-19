using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface IRoleRepository : IGenericRepository<UserManager<Client>>
    {
        Task<UserVM> UserRoleDetail(Client user);
        Task<UserVM> FindUserRole(Client user);
        Task<UserVM> UpdateUserRole(UserRoleVM userRole);
        Task ChangeUserRole(string newRole);
    }
}
