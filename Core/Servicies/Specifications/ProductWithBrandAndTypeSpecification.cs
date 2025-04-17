using Domain.Contracts;
using Domain.Entities;
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

        public ProductWithBrandAndTypeSpecification(string? sort , int? BrandId , int? Type) 
            : base(p=>
            (!BrandId.HasValue || p.BrandId == BrandId.Value)&&
            (!Type.HasValue || p.TypeId == Type.Value)
            )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            if (!string.IsNullOrEmpty(sort))
            {
                switch(sort.ToLower().Trim())
                {
                    case "priceAsc":
                        SetOrder(p => p.Price);
                        break;
                    case "pricedesc":
                        SetOrderdesc(p => p.Price);
                        break; 
                    case "namedesc":
                        SetOrderdesc(p => p.Name);
                        break;
                    default:
                        SetOrder(p => p.Name);
                        break;  
                }

            }
        }
    }
}
