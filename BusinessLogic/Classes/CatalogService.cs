using BusinessLogic.Interfaces;
using DAL.Generic;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Classes
{
    public class CatalogService : ICatalogService
    {
        private IDALContext _context;

        #region "Working with Catalog repository"

        public CatalogService(IDALContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            return _context.CategoryRepository.All().ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.CategoryRepository.Filter(c => c.CategoryID == categoryId).FirstOrDefault();
        }

        public Category CreateCategory(Category category)
        {
            var newCategory = _context.CategoryRepository.Create(category);

            return newCategory;
        }

        public int UpdateCategory(Category category)
        {
            return _context.CategoryRepository.Update(category);
        }

        public void DeleteCategory(int id)
        {
            var category = _context.CategoryRepository.Find(id);
            _context.CategoryRepository.Delete(category);
        }

        #endregion

        #region "Working with product repository"

        public List<Product> GetProducts()
        {
            return _context.ProductRepository.Filter(p => p.IsActive == true).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.ProductRepository.Filter(p => p.IsActive == true && p.ProductID == productId).FirstOrDefault();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _context.ProductRepository.Filter(p => p.CategoryID == categoryId).ToList();
        }

        public List<Product> GetSeasonProducts()
        {
            return _context.ProductRepository.Filter(p => p.IncludeToSeason == true && p.IsActive == true).ToList();
        }

        public int GetCategoryIdByProductId(int productId)
        {
            return _context.ProductRepository.Find(productId).CategoryID;
        }

        public Product CreateProduct(Product product)
        {
            product.DateCreated = DateTime.UtcNow;
            var newProduct = _context.ProductRepository.Create(product);
            return newProduct;
        }

        public int UpdateProduct(Product product)
        {
            return _context.ProductRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _context.ProductRepository.Find(id);
            _context.ProductRepository.Delete(product);
        }

        #endregion


        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
       
    }
}
