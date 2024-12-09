using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    //The framework will read 'Products' from the className and the url will be /api/Products/xxx 
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        // If other services are used, it's a convension to add '_'
        private readonly StoreContext _context;

        // The context will be auto-injected into the controller
        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        // Keep in mind the format of asynchronous methods
        public async Task <ActionResult<List<Product>>> GetProducts()
        {
            // Keep in mind the context.table_name_ToListAsync() method

            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        // The placeholder format
        // example: api/products/3
        [HttpGet("{id}")] 
        //Do not forget about the params
        public async Task <ActionResult<Product>> GetProduct(int id)
        {

             return await _context.Products.FindAsync(id);
            
        }
        
    }
}