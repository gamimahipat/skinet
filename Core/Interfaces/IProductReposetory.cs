using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductReposetory
    {
        Task<Product> GetProductByIdAsnc(int id);
        Task<IReadOnlyList<Product>> GetProductsAsnc();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsnc();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsnc();
    }
}