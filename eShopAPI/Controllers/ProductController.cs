using AutoMapper;
using eShopAPI.DTO_s;
using eShopAPI.Models;
using eShopAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var result = await _productRepository.AddProduct(product);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
