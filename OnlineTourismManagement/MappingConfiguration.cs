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
                config.CreateMap<SignUpViewModel, UserDetails>().ForMember(dest=>dest.UserRole,opt=>opt.MapFrom(src=>"User"));
                config.CreateMap<PackageViewModel, PackageDetails>()
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest=>dest.CreationDate,opt=>opt.MapFrom(src=>DateTime.Now));
                config.CreateMap<PackageDetails, PackageViewModel>();
            });
        }
    }
}