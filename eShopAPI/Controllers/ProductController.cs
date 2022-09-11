using AutoMapper;
using eShopAPI.DTO_s;
using eShopAPI.Interfaces;
using eShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
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
            var mappedProduct = _mapper.Map<Product>(productDto);
            var product = await _productRepository.AddProduct(mappedProduct);
            if (product == null)
            {
                return BadRequest();
            }
            var url = $"{Request.Scheme}://{Request.Host.Value}{Request.Path}/{product.Id}";
            return Created(url, product);
        }
    }
}
