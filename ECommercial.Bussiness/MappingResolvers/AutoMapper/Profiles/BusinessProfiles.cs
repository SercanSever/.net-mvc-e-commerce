using AutoMapper;
using ECommercial.Entities.Concrete;
using ECommercial.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercial.Bussiness.MappingResolvers.AutoMapper.Profiles
{
    public class BusinessProfiles : Profile
    {
        public BusinessProfiles()
        {
            CreateMap<Product, ProductWithImageDto>();
            CreateMap<ProductWithImageDto, Product>();
        }
    }
}
