using FeaturedServices.Common.Models.Image;
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
        Task<bool> CompanyHaveMainImage(int companyId);
        Task DeleteImage(ImageCompany image);
        Task<bool> HaveImage(int id);
        Task<ImageCompany> GetImageCompany(int companyId);
    }
}
