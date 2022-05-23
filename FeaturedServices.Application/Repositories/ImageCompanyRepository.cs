using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Repositories
{
    public class ImageCompanyRepository : GenericRepository<ImageCompany>, IImageCompanyRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public ImageCompanyRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, IMapper mapper, ICompanyRepository companyRepository) : base(context)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task AddImage(ImageCompanyVM imageCompanyVM)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageCompanyVM.ImageFile.FileName);
            string extension = Path.GetExtension(imageCompanyVM.ImageFile.FileName);
            var imageCompany = mapper.Map<ImageCompany>(imageCompanyVM);
            imageCompany.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageCompany.ImageFile.CopyToAsync(fileStream);
            }
            //Insert record
            imageCompany.CompanyId = (await companyRepository.CheckCompanyEdit()).Id;
            await AddAsync(imageCompany);
        }
    }
}
