using AutoMapper;
using FeaturedServices.Application.Contracts;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);

            var imageCompany = mapper.Map<ImageCompany>(imageCompanyVM);
            var date = DateTime.Now.ToString("yymmssfff");
            imageCompany.ImageName = fileName + date + extension;
            imageCompany.CompanyId = (await companyRepository.CheckCompanyEdit()).Id;

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await imageCompany.ImageFile.CopyToAsync(fileStream);
            }

            var test = new FileStream(path, FileMode.Open);
            using (Image image = Image.Load(test))
            {
                image.Mutate(x => x
                     .Resize(500, 300));

                image.Save(path + date + extension);
            }

            await AddAsync(imageCompany);
        }
    }
}
