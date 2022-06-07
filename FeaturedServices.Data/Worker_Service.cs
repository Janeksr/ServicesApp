using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Data
{
    public class Worker_Service
    {
        public int Id { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
