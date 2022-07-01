using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Common.Models.Service
{
    public class ServicesWithWorkerVM : ListOfServicesVM
    {
        public List<int> WorkerId { get; set; }
    }
}
