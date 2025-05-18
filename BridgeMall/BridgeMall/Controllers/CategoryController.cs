using AutoMapper;
using BridgeMall.Models.DTOs;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BridgeMall.Controllers
{
	[Route("api/category")]
	[ApiController]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet("getAllCategories")]
		public IActionResult GetAllCategories()
		{
			var categories = _categoryService.GetCategories();
			return Ok(categories);
		}

		[HttpGet("getCategories")]
		public IActionResult GetCategories(string? searchString)
		{
			var categories = _categoryService.GetCategories(searchString);
			return Ok(categories);
		}

		[HttpGet("getCategory/{categoryId}")]
		public IActionResult GetCategory(int categoryId)
		{
			var category = _categoryService.GetCategory(categoryId);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpPost("createCategory")]
		public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO)
		{
			if (categoryDTO == null)
			{
				return BadRequest("Category cannot be null");
			}
			return Ok(_categoryService.CreateCategory(_mapper.Map<Category>(categoryDTO)));
		}

		[HttpPut("updateCategory")]
		public IActionResult UpdateCategory(CategoryDTO categoryDTO)
		{
			if (categoryDTO == null)
			{
				return BadRequest("Category cannot be null");
			}
			return Ok(_categoryService.UpdateCategory(_mapper.Map<Category>(categoryDTO)));
		}

		[HttpDelete("deleteCategory/{categoryId}")]
		public IActionResult DeleteCategory(int categoryId)
		{
			return Ok(_categoryService.DeleteCategory(categoryId));
		}
	}
}
