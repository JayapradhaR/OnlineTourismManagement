using AutoMapper;
using OnlineTourismManagement.Entity;
using OnlineTourismManagement.Models;
using System;
using System.Collections.Generic;

namespace OnlineTourismManagement
{
    public class MappingConfiguration
    {
        public static void MapUserDetails()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpViewModel, Customer>().ForMember(dest=>dest.UserRole,opt=>opt.MapFrom(src=>"User"));
                config.CreateMap<SignInViewModel, Customer>();
                config.CreateMap<PackageViewModel, Package>()
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest=>dest.CreationDate,opt=>opt.MapFrom(src=>DateTime.Now));
                config.CreateMap<Package, PackageViewModel>();
                config.CreateMap<PackageTypeViewModel, PackageType>();
                config.CreateMap< PackageType, PackageTypeViewModel>();
                config.CreateMap<ItineraryViewModel,Itinerary>();
                config.CreateMap<Itinerary, ItineraryViewModel>();
                config.CreateMap<OrderViewModel, Order>().ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.Now));
                config.CreateMap<GiftCardTypeViewModel, GiftCardType>();
                config.CreateMap<GiftCardType, GiftCardTypeViewModel>();
            });
        }
    }
}