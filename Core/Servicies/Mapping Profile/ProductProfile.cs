using AutoMapper;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Mapping_Profile
{
    public class ProductProfile :Profile
    {

        public ProductProfile()
        {
            #region Produt 

            CreateMap<Product, ProductDTO>()
              .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.ProductBrand.Name))
              .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.ProductType.Name))
              .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>());

            #endregion

            #region Brand

            CreateMap<ProductBrand, BrandDTO>();

            #endregion

            #region Type 

            CreateMap<ProductType, TypeDTO>();

            #endregion


        }
    }
}
