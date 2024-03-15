using Application.PayLoads.DataResponse;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.Converter
{
    public class ProductVariantsConverter
    {
        public Response_ProductVariants EntityToDTO(ProductVariant pv)
        {
            Response_ProductVariants response = new Response_ProductVariants()
            {
                VariantName = pv.VariantName,
                Price=pv.Price,
                ShellPrice=pv.ShellPrice,
                Quanlity=pv.Quantity
            };
            
            return response;
        }
        public Response_ProductVariants EntityToDTOVariantProperty(ProductVariant pv)
        {
            Response_ProductVariants response = new Response_ProductVariants()
            {
                VariantName = pv.VariantName,
                Price = pv.Price,
                ShellPrice = pv.ShellPrice,
                Quanlity = pv.Quantity
            };

            return response;
        }
    }
}
