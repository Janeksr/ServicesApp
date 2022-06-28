using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;

namespace FeaturedServices.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyRepository companyRepository;

        public HomeController(ILogger<HomeController> logger, ICompanyRepository companyRepository)
        {
            _logger = logger;
            this.companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, string sort = "Name")
        {
            var query = await companyRepository.GetAllCompanies();

            var model = PagingList.Create(query, 2, pageIndex);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode = null)
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature != null)
            {
                Exception exception = exceptionHandlerPathFeature.Error;
                _logger.LogError(exception, $"Error Encountered By User: {this.User?.Identity?.Name} | Request Id: {requestId}");
            }
            if (statusCode.HasValue)
            {
                if(statusCode == 404 || statusCode == 500)
                {
                    var viewName = statusCode.ToString(); 
                    return View(viewName);
                }
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CompanyCreated()
        {
            return View();
        }
    }
}