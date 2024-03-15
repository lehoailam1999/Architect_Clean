using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductVariantRepositories:IProductVariantRepositories
    {
        private readonly AppDbContext _appDbContext;

        public ProductVariantRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ProductVariant GetProductVariantById(int id)
        {
           return _appDbContext.ProductVariants.SingleOrDefault(x=>x.VariantId==id);
        }
    }
}
