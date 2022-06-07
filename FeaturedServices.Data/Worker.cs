using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Data
{
    public class Worker : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Key { get; set; }
        public int TotalServices { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public ICollection<Worker_Service> Workers_Services { get; set; }
    }
}
