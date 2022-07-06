using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models.Image;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.CompanyCreated)]
    public class ImageController : Controller
    {
        private readonly IImageCompanyRepository imageCompanyRepository;
        private readonly ICompanyRepository companyRepository;

        public ImageController(IImageCompanyRepository imageCompanyRepository, ICompanyRepository companyRepository)
        {
            this.imageCompanyRepository = imageCompanyRepository;
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImageCompany(ImageCompanyVM imageCompanyVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await imageCompanyRepository.AddImage(imageCompanyVM))
                    {
                        return RedirectToAction("MyCompany", "Company");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error has occurred.");
            }
            return RedirectToAction("MyCompany", "Company", new { error = "CustomError", errorMsg = "En error has occurred." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMainImage()
        {
            var companyId = await companyRepository.GetCompanyId();
            var image = await imageCompanyRepository.GetImageCompany(companyId);
            if (image != null)
            {
                await imageCompanyRepository.DeleteImage(image);
                return RedirectToAction("MyCompany", "Company");
            }
            return RedirectToAction("MyCompany", "Company", new { error = "CustomError", errorMsg = "You do not have any image." });
        }
    }
}
