using AutoMapper;
using NLayerApi.Core.Dtos;
using NLayerApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApi.Service.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductFeatureDto, ProductFeature>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
        }
    }
}
