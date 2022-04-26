using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;


using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsControllers : ControllerBase
    {
        private readonly IProductReposetory _repo;
        public ProductsControllers(IProductReposetory repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repo.GetProductsAsnc();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsnc(id);
            return Ok(product);
        }
        
        [HttpGet("brands")]
        public async Task<IActionResult> GetProductsBrands()
        {
            var products = await _repo.GetProductBrandsAsnc();
            return Ok(products);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetProductsTypes()
        {
            var products = await _repo.GetProductTypesAsnc();
            return Ok(products);
        }

    }
}