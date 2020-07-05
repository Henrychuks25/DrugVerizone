using AutoMapper;
using DrugVerizone.Entities;
using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Profiles
{
    public class DrugsProfile : Profile
    {
        public DrugsProfile()
        {
            CreateMap<Drugs, DrugsViewDto>()
                .ForMember(dest => dest.Manufacturers,
                opt =>
                {
                    opt.PreCondition(src => src.Manufacturer != null);
                    opt.MapFrom(src => src.Manufacturer);
                });

            CreateMap<DrugCreateDto, Drugs>().ReverseMap();
            CreateMap<DrugUpdateDto, Drugs>().ReverseMap();
        }
    }
}
