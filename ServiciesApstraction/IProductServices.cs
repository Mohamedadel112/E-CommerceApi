using Shared;
using Shared.DTOs;

namespace Domain.Contracts
{
    public interface IProductServices
    {
       public Task <IEnumerable<ProductDTO>>GetAllProductsAsync(ProductParametersSpecification parameters);

        public Task<ProductDTO> GetProductByIdAsync(int id);

        public Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
        public Task<IEnumerable<TypeDTO>> GetAllTypesAsync();



    }
}
