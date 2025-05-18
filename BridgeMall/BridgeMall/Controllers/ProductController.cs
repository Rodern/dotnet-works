using AutoMapper;
using BridgeMall.Models.DTOs;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BridgeMall.Controllers
{
	[Route("api/product")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;
		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet("getAllProducts")]
		public IActionResult GetAllProducts()
		{
			var products = _productService.GetProducts();
			return Ok(products);
		}

		[HttpGet("getProducts")]
		public IActionResult GetProducts(string? searchString)
		{
			var products = _productService.GetProducts(searchString);
			return Ok(products);
		}

		[HttpGet("getProduct/{productId}")]
		public IActionResult GetProduct(int productId)
		{
			var product = _productService.GetProduct(productId);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost("createProduct")]
		public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
		{
			if (productDTO == null)
			{
				return BadRequest("Product cannot be null");
			}
			return Ok(_productService.CreateProduct(_mapper.Map<Product>(productDTO)));
		}

		[HttpPut("updateProduct")]
		public IActionResult UpdateProduct(ProductDTO productDTO)
		{
			if (productDTO == null)
			{
				return BadRequest("Product cannot be null");
			}
			return Ok(_productService.UpdateProduct(_mapper.Map<Product>(productDTO)));
		}

		[HttpDelete("deleteProduct/{productId}")]
		public IActionResult DeleteProduct(int productId)
		{
			return Ok(_productService.DeleteProduct(productId));
		}
	}
}
