using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        private readonly AppDbContext _context;
        public ProductRepositories(AppDbContext context)
        {
            _context = context;
           
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(x=>x.ProductId==id);
        }
        public IEnumerable<Product> GetProductWithQuantity(int id)
        {           
            var products = _context.Products
                    .Include(p => p.productVariants)
                    .Where(p => p.productVariants.Any(pv => pv.Quantity > id))
                    .Select(p => new Product
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        productVariants = p.productVariants.Where(pv => pv.Quantity > id).ToList()
                    })
                    .ToList();
            return products;
        }
        public IEnumerable<Product> GetProductWithPrice(decimal giadau, decimal giacuoi)
        {
            var productwithPrice = _context.Products.Include(x => x.productVariants)
                .Where(p => p.productVariants.Any(pv => pv.Price > giadau && pv.Price < giacuoi))
                .Select(p => new Product
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    productVariants = p.productVariants.Where(pv => pv.Price > giadau && pv.Price < giacuoi).ToList()
                }).ToList();
            return productwithPrice;

        }

        public IEnumerable<Product> GetAllProductInformation()
        {
           return _context.Products.ToList();
        }

        public bool AddProduct(Product p)
        {
            try
            {
                _context.Products.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            };
        }
    }
}
