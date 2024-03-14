using Application.PayLoads.Converter;
using Application.PayLoads.DataResponse;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.Converter
{
    public class ProductConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly ProductVariantsConverter _converter;
        public ProductConverter()
        {
            _appDbContext = new AppDbContext();
            _converter = new ProductVariantsConverter();
        }
        public Response_Product EntityToDTO(Product p)
        {
            Response_Product response= new Response_Product()
            {
                ProductName = p.ProductName,
            };
            if (p.ProductId!=null)
            {
                var pr = _appDbContext.ProductVariants.Where(x => x.ProductId == p.ProductId);
                if (pr!=null)
                {
                    response.productVariants = pr.Select(x => _converter.EntityToDTO(x));
                }
            }
            return response;
        }
    }
}
