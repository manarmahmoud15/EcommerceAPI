using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infrastructure.Context;
using core.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DBContext _Context;
        public ProductsController(DBContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products =await _Context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id )
        {
            var product = await _Context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
            { 
                return BadRequest("Invalid ID");
            }
            return Ok (product);
        }
    }
}
