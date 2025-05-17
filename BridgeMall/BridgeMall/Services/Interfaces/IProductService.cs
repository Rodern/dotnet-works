using BridgeMall.Models.Data;
using BridgeMall.Models.Relational;
using System.Collections.ObjectModel;

namespace BridgeMall.Services.Interfaces
{
    public interface IProductService
    {
        public ObservableCollection<Product> GetProducts();
        public ObservableCollection<Product> GetProducts(string? searchString);
        public ObservableCollection<Product> GetProductsByCategory(int categoryId);
        public Product GetProduct(int id);
        public CrudResponse CreateProduct(Product product);
        public CrudResponse DeleteProduct(int id);
        public CrudResponse UpdateProduct(Product product);
    }
}
