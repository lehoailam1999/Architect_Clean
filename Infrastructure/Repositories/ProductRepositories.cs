using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interface;

namespace Infrastructure.Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        private readonly AppDbContext _context;
        public ProductRepositories()
        {
            _context = new AppDbContext();
           
        }
        public Product GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(x=>x.ProductId==id);
        }
    }
}
