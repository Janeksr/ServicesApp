using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeaturedServices.Common.Models.User
{
    public class UserVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public SelectList? AllRoles { get; set; }

        [Required]
        [Display(Name = "Chose the role")]
        public string NewRole { get; set; }

        public UserRoleVM UserRole { get; set; }
    }
}
