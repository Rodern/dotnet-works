using BridgeMall.Contexts.RDB;
using BridgeMall.Models.CRUD;
using BridgeMall.Models.Data;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using System.Collections.ObjectModel;

namespace BridgeMall.Services.DB
{
	public class ProductService : IProductService
	{
		private readonly ICrud _crud;
		private readonly BridgeMallDbContext _dbContext;
		public ProductService(BridgeMallDbContext dbContext, ICrud crud)
		{
			_dbContext = dbContext;
			_crud = crud;
		}
		public CrudResponse CreateProduct(Product product)
		{
			return _crud.CreateEntity(product.ProductId, product);
		}

		public CrudResponse DeleteProduct(int id)
		{
			return _crud.DeleteEntity<Product>(id);
		}

		public Product GetProduct(int id)
		{
			return _crud.GetEntity<Product>(id);
		}

		public ObservableCollection<Product> GetProducts()
		{
			return new(_dbContext.Products);
		}

		public ObservableCollection<Product> GetProducts(string? searchString)
		{
			if (string.IsNullOrEmpty(searchString))
			{
				return new(_dbContext.Products);
			}
			else
			{
				return new(_dbContext.Products.Where(x => x.Name.ToLower().Contains(searchString!.ToLower())));
			}
		}

		public ObservableCollection<Product> GetProductsByCategory(int categoryId)
		{
			return new(_dbContext.Products.Where(x => x.CategoryId == categoryId));
		}

		public CrudResponse UpdateProduct(Product product)
		{
			return _crud.UpdateEntity(product.ProductId, product);
		}
	}
}
