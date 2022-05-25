using FeaturedServices.Common.Models;
using FeaturedServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturedServices.Application.Contracts
{
    public interface IImageCompanyRepository : IGenericRepository<ImageCompany>
    {
        Task<bool> AddImage(ImageCompanyVM imageCompanyVM);
        Task<bool> CheckIfCompanyHaveMainImage(Company company);
        Task DeleteImage(ImageCompany image);
        Task<bool> HaveImage();
    }
}
