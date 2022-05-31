using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Data
{
    public class WorkerService
    {
        public int WorkerId { get; set; }
        public int ServiceId { get; set; }
        public Worker Worker { get; set; }
        public Service Service { get; set; }
    }
}
