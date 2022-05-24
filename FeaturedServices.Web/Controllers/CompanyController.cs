using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.Company + ", " + Roles.CompanyCreated)]
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ICompanyRepository companyRepository;
        private readonly ICompanyTypeRepository companyTypeRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IWorkerRepository workerRepository;

        public CompanyController(ApplicationDbContext context, ICompanyRepository companyRepository,
            ICompanyTypeRepository companyTypeRepository, IRoleRepository roleRepository, IWorkerRepository workerRepository)
        {
            this.context = context;
            this.companyRepository = companyRepository;
            this.companyTypeRepository = companyTypeRepository;
            this.roleRepository = roleRepository;
            this.workerRepository = workerRepository;
        }

        [Authorize(Roles = Roles.Company)]
        public IActionResult Create()
        {
            var model = new CompanyVM
            {
                CompanyTypes = new SelectList(context.CompanyTypes, "Id", "Name")
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
                        return View(nameof(MyCompany));
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "En error has occurred.");
            }
            return View(model);
        }

        public async Task<IActionResult> MyCompany()
        {
            var company = await companyRepository.GetCompanyDetails();
            var model = new CompanyWithWorkerVM {companyVM = company, workerVM = await workerRepository.GetWorkers()};
            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            var model = await companyRepository.GetCompanyDetails();
            if (model == null) return NotFound();
            model.CompanyTypes = new SelectList(context.CompanyTypes, "Id", "Name");
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
            companyVM.CompanyTypes = new SelectList(context.CompanyTypes, "Id", "Name");
            return View("Edit", companyVM);
        }

        public async Task<IActionResult> PreviewCompany()
        {
            var model = await companyRepository.GetCompany();
            return View(model);
        }

    }
}
