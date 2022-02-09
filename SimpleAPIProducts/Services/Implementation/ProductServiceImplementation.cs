using Microsoft.Extensions.Logging;
using SimpleAPIProducts.Controllers;
using SimpleAPIProducts.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAPIProducts.Services.Implementation
{
    public class ProductServiceImplementation : IProductService
    {
        SqlServerContext _context;

        public ProductServiceImplementation(ILogger<ProductController> logger, SqlServerContext context)
        {
            _context = context;
        }

        public Product Create(Product product)
        {
            try
            {
                _context.Add(product);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return product;
        }

        public Product Delete(long id)
        {
        
            var itemDesejado = FindById(id);

            if (itemDesejado is not null)
            {
                _context.Products.Remove(itemDesejado);
                _context.SaveChanges();
            }

            return itemDesejado;
        }

        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }

        public Product FindById(long id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        public Product Update(Product product)
        {
            var item = FindById(product.Id);

            if (item != null)
            {
                try
                {
                    _context.Entry(item).CurrentValues.SetValues(product);
                    _context.SaveChanges();
                }

                catch
                {
                    throw;
                }
            }

            else
            {
                return new Product();
            }

            return item;
        }


    }
}
