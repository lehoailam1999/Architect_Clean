using Appication.PayLoads.DataResponse;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.Converter
{
    public class ProductVariantWithVariantPropertiesConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly VariantPropertiesConverter _converter;

        public ProductVariantWithVariantPropertiesConverter(AppDbContext appDbContext, VariantPropertiesConverter converter)
        {
            _appDbContext = appDbContext;
            _converter = converter;
        }
        public DataResponse_ProductVariantsWithVariantProperties EntityToDTO(ProductVariant pv)
        {
            DataResponse_ProductVariantsWithVariantProperties res = new DataResponse_ProductVariantsWithVariantProperties() 
            { 
                ProductName=_appDbContext.Products.SingleOrDefault(x=>x.ProductId==pv.ProductId).ProductName,
                VariantName=pv.VariantName,
                Quantity=pv.Quantity,
                Price=pv.Price,
                ShellPrice=pv.ShellPrice
            };
            if (pv.VariantId!=null)
            {
                var variantproduct = _appDbContext.VariantProperties.Where(x => x.VariantId == pv.VariantId);
                if (variantproduct != null)
                {
                    res.variantProperties = variantproduct.Select(x=>_converter.EntityToDTO(x));
                }
            }
            return res;

        }
    }
}
