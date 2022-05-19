using System.ComponentModel.DataAnnotations;

namespace FeaturedServices.Common.Models
{
    public class CompanyTypeVM
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

    }
}
