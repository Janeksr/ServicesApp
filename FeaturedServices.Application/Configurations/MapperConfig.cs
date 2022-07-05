using AutoMapper;
using FeaturedServices.Common.Models.Company;
using FeaturedServices.Common.Models.CompanyType;
using FeaturedServices.Common.Models.Image;
using FeaturedServices.Common.Models.Reservation;
using FeaturedServices.Common.Models.Service;
using FeaturedServices.Common.Models.User;
using FeaturedServices.Common.Models.Worker;
using FeaturedServices.Common.Models.WorkerServices;
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
            CreateMap<Worker, WorkerServicesNbVM>().ReverseMap();
            CreateMap<Service, ServiceVM>().ReverseMap();
            CreateMap<Service, ServiceEditVM>().ReverseMap();
            CreateMap<ImageCompany, ImageCompanyVM>().ReverseMap();
            CreateMap<Reservation, ReservationVM>().ReverseMap();
            CreateMap<Reservation, NewReservationVM>().ReverseMap();
        }
    }
}
