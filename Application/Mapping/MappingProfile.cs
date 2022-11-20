using Application.CQRS.DTOs.Admin;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDetailDto>().ReverseMap();
            CreateMap<Category, CategoriesDto>().ReverseMap();
            CreateMap<City, CitiesDto>().ReverseMap();
        }
    }
}
