using AutoMapper;
using HsumChaint.Application.DTOs;
using HsumChaint.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HsumChaint.Application.Mappings
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ReverseMap();

            //CreateMap<UserDto, User>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
