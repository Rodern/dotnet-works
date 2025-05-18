using BridgeMall.Contexts.RDB;
using BridgeMall.Models.CRUD;
using BridgeMall.Models.Data;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using System.Collections.ObjectModel;

namespace BridgeMall.Services.DB
{
    public class CategoryService : ICategoryService
    {
        private readonly ICrud _crud;
        private readonly BridgeMallDbContext _dbContext;
        public CategoryService(BridgeMallDbContext dbContext, ICrud crud)
        {
            _dbContext = dbContext;
            _crud = crud;
        }
        public CrudResponse CreateCategory(Category category)
        {
            return _crud.CreateEntity(category.CategoryId, category);
        }

        public CrudResponse DeleteCategory(int id)
        {
            return _crud.DeleteEntity<Category>(id);
        }

        public ObservableCollection<Category> GetCategories()
        {
            return new(_dbContext.Categories);
        }

        public ObservableCollection<Category> GetCategories(string? searchString)
        {
			if (string.IsNullOrEmpty(searchString))
			{
				return new(_dbContext.Categories);
			}
			else
			{
				return new(_dbContext.Categories.Where(x => x.Name.ToLower().Contains(searchString!.ToLower())));
			}
        }

        public Category GetCategory(int id)
        {
            return _crud.GetEntity<Category>(id);
        }

        public CrudResponse UpdateCategory(Category category)
        {
            return _crud.UpdateEntity(category.CategoryId, category);
        }
    }
}
