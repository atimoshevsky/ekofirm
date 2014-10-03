using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generic
{
    public class DALContext: IDALContext
    {
        private readonly ApplicationDBContext _context;
        private IRepository<Category> _categories;
        private IRepository<Product> _products;


        public DALContext(IConnectionFactory connectionFactory)
        {
            _context = new ApplicationDBContext(connectionFactory.ConnectionString);
        }

        public IRepository<Category> CategoryRepository
        {
            get {
                if (_categories == null)
                    _categories = new Repository<Category>(_context);
                return _categories;
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_products == null)
                    _products = new Repository<Product>(_context);
                return _products;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            if (_categories != null)
                _categories.Dispose();

            if (_products != null)
                _products.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
