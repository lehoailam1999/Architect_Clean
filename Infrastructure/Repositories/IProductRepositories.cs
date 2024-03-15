using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IProductRepositories
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductInformation();
        IEnumerable<Product> GetProductWithQuantity(int id);
        IEnumerable<Product> GetProductWithPrice(decimal giadau,decimal giacuoi);
        bool AddProduct(Product p);

    }
}
