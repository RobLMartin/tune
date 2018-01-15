using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using tune.Models;
using tune.Dtos;

namespace tune.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Album, AlbumDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<AlbumDto, Album>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}