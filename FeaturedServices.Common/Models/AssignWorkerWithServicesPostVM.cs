using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models
{
    public class AssignWorkerWithServicesPostVM
    {
        public List<int>? SelectedServices { get; set; }
        public int WorkerId { get; set; }

    }
}
