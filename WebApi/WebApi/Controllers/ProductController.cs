using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  IProductServices _productSevice;

        public ProductController(IProductServices productService)
        {
            _productSevice = productService;
        }
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var products = _productSevice.GetAll();

            return products;
        }
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productSevice.Get(id);

            if (product == null)
                return NotFound();

            return product;
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productSevice.AddProduct(product);
            return CreatedAtAction(nameof(Create), new { id = product.Id }, product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productSevice.Remove(id);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Update(this int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var existingPizza = _productSevice.Get(id);
            if (existingPizza is null)
                return NotFound();

            _productSevice.Update(product);
            return Ok();
        }
    }
}
