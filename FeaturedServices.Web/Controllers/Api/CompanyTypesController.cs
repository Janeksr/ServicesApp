using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models.CompanyType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypesController : ControllerBase
    {
        private readonly ICompanyTypeRepository _companyTypeRepository;
        public CompanyTypesController(ICompanyTypeRepository companyTypeRepository)
        {
            _companyTypeRepository = companyTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyTypeVM>>> Index()
        {
            var model = await _companyTypeRepository.GetAllCompanyTypes();
            return model;
        }
    }
}
