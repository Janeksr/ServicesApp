using AutoMapper;
using FeaturedServices.Common.Models;
using FeaturedServices.Data;

namespace FeaturedServices.Application.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CompanyType, CompanyTypeVM>().ReverseMap();
            CreateMap<Client, UserVM>().ReverseMap();
            CreateMap<Company, CompanyVM>().ReverseMap();
            CreateMap<Worker, WorkerVM>().ReverseMap();
            CreateMap<Service, ServiceVM>().ReverseMap();
            CreateMap<Service, ServiceEditVM>().ReverseMap();
            CreateMap<ImageCompany, ImageCompanyVM>().ReverseMap();


            
        }
    }
}
