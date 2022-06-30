using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeaturedServices.Data;
using FeaturedServices.Application.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using FeaturedServices.Common.Constants;
using FeaturedServices.Common.Models.CompanyType;

namespace FeaturedServices.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class CompanyTypesController : Controller
    {
        private readonly ICompanyTypeRepository companyTypeRepository;
        private readonly IMapper mapper;

        public CompanyTypesController(ICompanyTypeRepository companyTypeRepository, IMapper mapper)
        {
            this.companyTypeRepository = companyTypeRepository;
            this.mapper = mapper;
        }

        // GET: CompanyTypes
        public async Task<IActionResult> Index()
        {
            var model = mapper.Map<List<CompanyTypeVM>>(await companyTypeRepository.GetAllAsync());
            return View(model);
        }

        // GET: CompanyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyTypeVM companyTypeVM)
        {
            if (ModelState.IsValid)
            {
                var model = mapper.Map<CompanyType>(companyTypeVM);
                await companyTypeRepository.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(companyTypeVM);
        }

        // GET: CompanyTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var model = await companyTypeRepository.GetAsync(id);
            
            var companyTypeVM = mapper.Map<CompanyTypeVM>(model);
            return View(companyTypeVM);
        }

        // POST: CompanyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanyTypeVM companyTypeVM)
        {
            if (id != companyTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var model = mapper.Map<CompanyType>(companyTypeVM);
                    await companyTypeRepository.UpdateAsync(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await companyTypeRepository.Exists(companyTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(companyTypeVM);
        }

        // POST: CompanyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await companyTypeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
