using Shared;

namespace Domain.Contracts
{
    public interface IProductServices
    {
       public Task <IEnumerable<ProductDTO>>GetAllProductsAsync(string? sort, int? BrandId, int? Type);

        public Task<ProductDTO> GetProductByIdAsync(int id);

        public Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
        public Task<IEnumerable<TypeDTO>> GetAllTypesAsync();



    }
}
