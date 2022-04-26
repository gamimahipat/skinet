using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductReposetory
    {
        private readonly StoreContext _db;
        public ProductRepository(StoreContext db)
        {
            _db = db;
        }

        public async Task<Product> GetProductByIdAsnc(int id)
        {
            return await _db.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsnc()
        {
            return await _db.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsnc()
        {
            return await _db.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsnc()
        {
            return await _db.ProductTypes.ToListAsync();
        }
    }
}