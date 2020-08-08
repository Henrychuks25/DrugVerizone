using AutoMapper;
using DrugVerizone.Entities;
using DrugVerizone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugVerizone.Profiles
{
    public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {
            CreateMap<Complaints, ComplaintViewDto>();

            CreateMap<ComplaintsCreateDto, Complaints>().ReverseMap();
            CreateMap<ComplaintsUpdateDto, Complaints>().ReverseMap();
        }
    }
}
