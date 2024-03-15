using Appication.PayLoads.DataResponse.DataResponse_Product;
using Application.PayLoads.DataResponse.DataResponse_Product;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.Converter.SanPhamConverter
{
    public class ProductVariant_Product_Converter
    {
        private readonly AppDbContext _appDbContext;
        private readonly VariantProperty_Product_Converter _converter;
        public ProductVariant_Product_Converter(AppDbContext appDbContext, VariantProperty_Product_Converter converter)
        {
            _appDbContext = appDbContext;
            _converter = converter;
        }
        public List<Response_ProductVariants_Product> EntityToDTO(List<ProductVariant> productVariant)
        {
            List<Response_ProductVariants_Product> list = new List<Response_ProductVariants_Product>();
            foreach (var item in productVariant)
            {
                Response_ProductVariants_Product response = new Response_ProductVariants_Product()
                {
                    VariantName = item.VariantName,
                    Quanlity = item.Quantity,
                    Price = item.Price,
                    ShellPrice = item.ShellPrice
                };
                if (item.VariantId != null)
                {
                    var property = _appDbContext.VariantProperties.Where(x => x.VariantId == item.VariantId).ToList();
                    if (property != null)
                    {
                        response.response_VariantProperties = _converter.EntityToDTO(property).AsQueryable();
                    }
                }
                list.Add(response);
            }
           
            return list;
        }

    }
}
