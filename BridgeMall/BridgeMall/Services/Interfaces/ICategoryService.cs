using BridgeMall.Models.Data;
using BridgeMall.Models.Relational;
using System.Collections.ObjectModel;

namespace BridgeMall.Services.Interfaces
{
    public interface ICategoryService
    {
        public ObservableCollection<Category> GetCategories();
        public ObservableCollection<Category> GetCategories(string? searchString);
        public Category GetCategory(int id);
        public CrudResponse CreateCategory(Category category);
        public CrudResponse DeleteCategory(int id);
        public CrudResponse UpdateCategory(Category category);
    }
}
