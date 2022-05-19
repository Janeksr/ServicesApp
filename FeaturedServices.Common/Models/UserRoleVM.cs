using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class UserRoleVM
    {
        [Display(Name = "Choose New Role")]
        public string NewRole { get; set; }
        public string Email { get; set; }
    }
}
