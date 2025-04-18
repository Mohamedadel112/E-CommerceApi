using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Servicies.Specifications;
using Shared;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Servicies
{
    public class ProductServices(IUnitOfWork unitOfWork , IMapper mapper) : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        #region Steps 

        /*
       * 1- get All Products From Database 
       *      - Inject the DbContext
       * 2- Map the Product to ProductDTO
       *      - Use AutoMapper
       * 3- return the List of ProductDTO
       *      
       */
        #endregion
        public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
        {
            var brands= await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync();  
            var BrandsDTO = _mapper.Map<IEnumerable<BrandDTO>>(brands);
            return BrandsDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync(ProductParametersSpecification parameters)
        {
            var Products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecification(parameters));
            var ProductsDTO = _mapper.Map<IEnumerable<ProductDTO>>(Products);
            return ProductsDTO;
        }

        public async Task<IEnumerable<TypeDTO>> GetAllTypesAsync()
        {
            var Types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var TypesDTO = _mapper.Map<IEnumerable<TypeDTO>>(Types);
            return TypesDTO;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var Product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(new ProductWithBrandAndTypeSpecification(id));
            //var ProductDTO = _mapper.Map<ProductDTO>(Product);
            return Product is null ? throw new ProductNotFoundException(id) : _mapper.Map<ProductDTO>(Product);
        }
    }
}
