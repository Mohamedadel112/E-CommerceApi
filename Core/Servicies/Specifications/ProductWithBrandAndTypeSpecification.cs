using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Specifications
{
    public class ProductWithBrandAndTypeSpecification :Specification<Product>
    {

        public ProductWithBrandAndTypeSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType); 
        }

        public ProductWithBrandAndTypeSpecification(ProductParametersSpecification parameters) 
            : base(p=>
            (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId.Value)&&
            (!parameters.TypeId.HasValue || p.TypeId == parameters.TypeId.Value)&&
            (string.IsNullOrWhiteSpace(parameters.Search)|| p.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
            
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            if (parameters.sort is not null)
            {
                switch(parameters.sort)
                {
                    case SortOptions.PriceAsc:
                        SetOrder(p => p.Price);
                        break;
                    case SortOptions.PriceDesc:
                        SetOrderdesc(p => p.Price);
                        break; 
                    case SortOptions.NameDesc:
                        SetOrderdesc(p => p.Name);
                        break;
                    default:
                        SetOrder(p => p.Name);
                        break;  
                }

            }

            ApplyPagienation(parameters.PageIndex, parameters.PageSize);
        }
    }
}
