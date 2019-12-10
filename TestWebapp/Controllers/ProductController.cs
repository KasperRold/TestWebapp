using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWebapp.Data;
using TestWebapp.Data.EFCore;
using TestWebapp.Models;

namespace TestWebapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("gettotalprice")]
        [HttpGet]
        public virtual async Task<double> GetTotalPrice()
        {
            var productList = await _productRepository.GetAll();

            double totalPrice = 0;

            foreach (var product in productList)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var product = await _productRepository.Get(id);
            return product;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody]Product product)
        {
            try
            {
                await _productRepository.Add(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            
            
        }

        [Route("test")]
        [HttpGet]
        public virtual string Test()
        {

            return "Hej";
        }
    }
}