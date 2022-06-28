using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.Company + ", " + Roles.CompanyCreated)]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyTypeRepository companyTypeRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IWorkerRepository workerRepository;
        private readonly IServiceRepository serviceRepository;
        private readonly IImageCompanyRepository imageCompanyRepository;
        private readonly SignInManager<Client> signInManager;

        public CompanyController( 
            ICompanyRepository companyRepository,
            ICompanyTypeRepository companyTypeRepository, 
            IRoleRepository roleRepository, 
            IWorkerRepository workerRepository,
            IServiceRepository serviceRepository, 
            IImageCompanyRepository imageCompanyRepository,
            SignInManager<Client> signInManager)
        {
            this.companyRepository = companyRepository;
            this.companyTypeRepository = companyTypeRepository;
            this.roleRepository = roleRepository;
            this.workerRepository = workerRepository;
            this.serviceRepository = serviceRepository;
            this.imageCompanyRepository = imageCompanyRepository;
            this.signInManager = signInManager;
        }

        [Authorize(Roles = Roles.Company)]
        public async Task<IActionResult> Create()
        {
            var model = new CompanyVM
            {
                CompanyTypes = await companyTypeRepository.GetSelectListCompaniesTypes()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await companyRepository.CreateCompany(model))
                    {

                        model.CompanyType = await companyTypeRepository.GetCompanyType(model.CompanyTypeId);
                        await roleRepository.ChangeUserRole(Roles.CompanyCreated);
                        await signInManager.SignOutAsync();
                        return RedirectToAction("CompanyCreated", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error has occurred.");
            }
            return View(model);
        }

        public async Task<IActionResult> MyCompany(string? error, string? errorMsg)
        {
            var company = await companyRepository.GetCompanyDetails();
            var haveImage = await imageCompanyRepository.HaveImage(company.Id);
            var workerServicesNbVMs = await workerRepository.GetWorkers();

            var model = new CompanyPanelVM { companyVM = company, workerVMs = workerServicesNbVMs, HaveImage = haveImage };
            
            if(error != null && errorMsg != null) ModelState.AddModelError(error, errorMsg);

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await companyRepository.GetCompanyDetails();
            if (model == null) return NotFound();
            model.CompanyTypes = await companyTypeRepository.GetSelectListCompaniesTypes();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyVM companyVM)
        {
            if (id != companyVM.Id) return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                    if (await companyRepository.UpdateCompany(id, companyVM))
                    {
                        return RedirectToAction(nameof(MyCompany));
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error has occurred.");
            }
            ModelState.AddModelError(string.Empty, "En error has occurred.");
            companyVM.CompanyTypes = await companyTypeRepository.GetSelectListCompaniesTypes();
            return View("Edit", companyVM);
        }

        public async Task<IActionResult> PreviewCompany()
        {
            var model = await companyRepository.GetCompany();
            if (model == null)
            {
                ModelState.AddModelError("CustomError", "Please check if You have added image and any service to your company.");
                return View(model);
            }
            return View(model);
        }

        [AllowAnonymous]
        [Route("{controller}/{action}/{id}")]
        public async Task<IActionResult> ViewCompany(int id)
        {
            var model = await companyRepository.GetCompanyForUser(id);
            if (model == null) return NotFound();
            return View(model);
        }

    }
}
