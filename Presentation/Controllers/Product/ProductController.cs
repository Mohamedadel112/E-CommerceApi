using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiciesApstraction;
using Shared;
using Shared.DTOs;
using Shared.ErrorsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers.Product
{
   
    public class ProductController(IServicesManager servicesManager) : ApiController
    {

        [RedisCache]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts([FromQuery]ProductParametersSpecification parameters)
        {
            var Products = await servicesManager.ProductServices.GetAllProductsAsync(parameters);
            return Ok(Products);
        }




        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAllBrands()
        {
            var Brands = await servicesManager.ProductServices.GetAllBrandsAsync();
            return Ok(Brands);
        }



        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDTO>>> GetAllTypes()
        {
            var Types = await servicesManager.ProductServices.GetAllTypesAsync();
            return Ok(Types);
        }



        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetAllProductById(int id)
        {
            if(id > 0)
            {
                var Product = await servicesManager.ProductServices.GetProductByIdAsync(id);
                return Ok(Product);
            }
            else 
                return NotFound();
        }

    }
}
