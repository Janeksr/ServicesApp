using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Data
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }

        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }
        public int WorkerId { get; set; }
    }
}
