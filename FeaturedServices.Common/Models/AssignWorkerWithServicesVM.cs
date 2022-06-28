using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class AssignWorkerWithServicesVM
    {
        public int WorkerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<SelectListItem> ServicesList { get; set; }

        public AssignWorkerWithServicesVM(int workerId, List<SelectListItem> servicesList, string firstname, string lastname)
        {
            WorkerId = workerId;
            ServicesList = servicesList;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
