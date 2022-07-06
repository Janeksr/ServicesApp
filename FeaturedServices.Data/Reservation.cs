using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Data
{
    public class Reservation : BaseEntity
    {
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        public string ClientId { get; set; }

        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }
        public int WorkerId { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        public int ServiceId { get; set; }

        public int CompanyId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Canceled { get; set; }
    }
}
