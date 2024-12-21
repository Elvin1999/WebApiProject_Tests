using Microsoft.AspNetCore.Mvc;
using WebApiProject.Entities;
using WebApiProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll(int top)
        {
            var products = _productService.GetProducts(top);
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var item = _productService.GetProductById(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            var products = _productService.GetProducts();
            product.Id = products.Count() > 0 ? products.Max(p => p.Id) + 1 : 1;
            _productService.Add(product);
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            var item = _productService.Update(product);
            return Ok(item);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
