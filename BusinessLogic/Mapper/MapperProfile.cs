using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Models.DTO.CategoryDTO;
using BusinessLogic.Models.DTO.ProductDTO;
using Data.Entities;

namespace BusinessLogic.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductAddUIDTO, Product>()
                .ForMember(m => m.Color, mo => mo.MapFrom(sm => sm.ColorInfo))
                .ReverseMap();
            CreateMap<Product, ProductUpdateUIDTO>().ReverseMap();
            CreateMap<Category, CategoryAddUIDTO>().ReverseMap();
        }
    }
}
