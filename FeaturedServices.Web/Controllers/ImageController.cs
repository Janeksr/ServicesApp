using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IImageCompanyRepository imageCompanyRepository;

        public ImageController(ApplicationDbContext context, IImageCompanyRepository imageCompanyRepository)
        {
            this.context = context;
            this.imageCompanyRepository = imageCompanyRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImageCompany(ImageCompanyVM imageCompanyVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await imageCompanyRepository.AddImage(imageCompanyVM);
                    return RedirectToAction("MyCompany", "Company");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error has occurred.");
            }
            return RedirectToAction("MyCompany", "Company");
        }
    }
}
