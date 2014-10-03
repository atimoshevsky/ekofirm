using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICatalogService : IDisposable
    {

        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        Category CreateCategory(Category category);
        int UpdateCategory(Category category);
        void DeleteCategory(int id);


        List<Product> GetProducts();
        Product GetProductById(int productId);
        List<Product> GetProductsByCategoryId(int categoryId);
        List<Product> GetSeasonProducts();
        int GetCategoryIdByProductId(int productId);
        Product CreateProduct(Product product);
        int UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
