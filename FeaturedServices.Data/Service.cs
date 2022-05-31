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

        [Column(TypeName = "decimal(5,2)")]
        public decimal Value { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public ICollection<WorkerService> WorkerServices { get; set; }
    }
}
