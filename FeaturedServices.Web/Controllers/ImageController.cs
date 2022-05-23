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
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public ImageController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IMapper mapper, ICompanyRepository companyRepository)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
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
                    string wwwRootPath = webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(imageCompanyVM.ImageFile.FileName);
                    string extension = Path.GetExtension(imageCompanyVM.ImageFile.FileName);
                    var imageCompany = mapper.Map<ImageCompany>(imageCompanyVM);
                    imageCompany.ImageName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await imageCompany.ImageFile.CopyToAsync(fileStream);
                    }
                    //Insert record
                    imageCompany.CompanyId = (await companyRepository.CheckCompanyEdit()).Id;
                    context.Add(imageCompany);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }
}
