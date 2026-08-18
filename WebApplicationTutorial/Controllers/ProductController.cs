using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationTutorial.Interfaces;
using WebApplicationTutorial.Models;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IService _productService;
        private readonly SHAHashingService _hashingService;

        private readonly HMACHashingService _hMACHashingService;

        public ProductsController(IService productService, SHAHashingService hashingService, HMACHashingService hMACHashingService)
        {
            _productService = productService;
            _hashingService = hashingService;
            _hMACHashingService = hMACHashingService;
        }
        private static List<Product> products = new List<Product>();

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            List<Product> response = _productService.GetAll();
            Response.Headers["X-Request-Hash"] = _hMACHashingService.GetHash(response);
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
              Product p = _productService.GetById(id);
            if (p == null) {
                return Ok(p);
            }
            else
            {
             return NotFound("Product not found");
            }
    
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {


            return Ok(_productService.AddProducts(p));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id,int id2)
        {
            return Ok(_productService.Update(id,id2));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id));
        }


        [HttpPost("check")]
        public IActionResult Check(List<Product> p,String hashed)
        {
            return Ok(_hashingService.VerifyHash(hashed, p));

        }

        [HttpPost("checkv2")]
        public IActionResult Checkv2(List<Product> p, [FromHeader(Name = "X-Request-Hash")] string hashed)
        {
            return Ok(_hashingService.VerifyHash(hashed, p));

        }
    }
}