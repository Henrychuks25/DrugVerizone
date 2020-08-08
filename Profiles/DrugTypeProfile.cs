using AutoMapper;
using DrugVerizone.Entities;
using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Profiles
{
    public class DrugTypeProfile : Profile
    {
        public DrugTypeProfile()
        {
            CreateMap<DrugTypes, DrugTypeViewDto>();

            CreateMap<DrugTypeCreateDto, DrugTypes>().ReverseMap();
            CreateMap<DrugTypeUpdateDto, DrugTypes>().ReverseMap();
        }
    }
}
