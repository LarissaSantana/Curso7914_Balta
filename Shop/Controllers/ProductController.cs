using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var produtcs = await context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();

            return Ok(produtcs);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id,
           [FromServices] DataContext context)
        {
            var product = await context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(product);
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(int id,
            [FromServices] DataContext context)
        {
            var products = await context.Products
                            .Include(p => p.Category)
                            .AsNoTracking()
                            .Where(p => p.CategoryId == id)
                            .ToListAsync();

            return products;
        }
    }
}
