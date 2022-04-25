using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;


using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsControllers : ControllerBase
    {
        private readonly StoreContext db;
        public ProductsControllers(StoreContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            return Ok(product);
        }


    }
}