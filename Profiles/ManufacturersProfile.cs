using AutoMapper;
using DrugVerizone.Entities;
using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Profiles
{
    public class ManufacturersProfile : Profile
    {
        public ManufacturersProfile()
        {
            CreateMap<Manufacturer, ManufacturerViewDto>()
                .ForMember(dest => dest.Drugs,
                opt =>
                {
                    opt.PreCondition(src => src.Drugs != null);
                    opt.MapFrom(src => src.Drugs);
                });

            CreateMap<ManufacturerCreateDto, Manufacturer>().ReverseMap();
            CreateMap<ManufacturerUpdateDto, Manufacturer>().ReverseMap();
        }
    }
}
