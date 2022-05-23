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
        Task AddImage(ImageCompanyVM imageCompanyVM);
    }
}
