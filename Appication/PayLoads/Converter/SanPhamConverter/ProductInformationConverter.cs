using Appication.PayLoads.DataResponse.DataResponse_Product;
using Application.PayLoads.Converter;
using Application.PayLoads.DataResponse;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.Converter.SanPhamConverter
{
    public class ProductInformationConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly ProductVariant_Product_Converter _productVariant_Product_Converter;

        public ProductInformationConverter(AppDbContext appDbContext, ProductVariant_Product_Converter productVariant_Product_Converter)
        {
            _appDbContext = appDbContext;
            _productVariant_Product_Converter = productVariant_Product_Converter;
        }
        public List<Response_ProductInformation> AllEntityToDTO(List<Product> listp)
        {
            List<Response_ProductInformation> list = new List<Response_ProductInformation>();

            foreach (var item in listp)
            {
                Response_ProductInformation response = new Response_ProductInformation()
                {
                    ProductName = item.ProductName
                };
                if (item.ProductId != null)
                {
                    var pr = _appDbContext.ProductVariants.Where(x => x.ProductId == item.ProductId).ToList();
                    if (pr != null)
                    {
                        response.productVariants = _productVariant_Product_Converter.EntityToDTO(pr).AsQueryable();
                    }
                }
                list.Add(response);

            }
            return list;
        }
    }
}
