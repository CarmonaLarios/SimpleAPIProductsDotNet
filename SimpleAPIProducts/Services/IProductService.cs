using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAPIProducts.Services
{
    public interface IProductService
    {
        Product Create(Product product);
        List<Product> FindAll();
        Product FindById(long id);
        Product Delete(long id);

        Product Update(Product product);
    }
}
