using System.ComponentModel.DataAnnotations;

namespace FeaturedServices.Common.Models.CompanyType
{
    public class CompanyTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
