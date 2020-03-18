using AutoMapper;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using System;

namespace OnlineTourismManagement
{
    public class MappingConfiguration
    {
        public static void MapUserDetails()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpViewModel, User>().ForMember(dest=>dest.UserRole,opt=>opt.MapFrom(src=>"User"));
                config.CreateMap<PackageViewModel, Package>()
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest=>dest.CreationDate,opt=>opt.MapFrom(src=>DateTime.Now));
                config.CreateMap<Package, PackageViewModel>();
                config.CreateMap<PackageTypeViewModel, PackageType>();
                config.CreateMap< PackageType, PackageTypeViewModel>();
                config.CreateMap<ItineraryViewModels, Itinerary>();
            });
        }
    }
}