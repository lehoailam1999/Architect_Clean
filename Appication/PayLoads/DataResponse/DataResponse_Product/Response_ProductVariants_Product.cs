using Appication.PayLoads.DataResponse;
using Appication.PayLoads.DataResponse.DataResponse_Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.DataResponse.DataResponse_Product
{
    public class Response_ProductVariants_Product
    {
        public string VariantName { get; set; }
        public int Quanlity { get; set; }
        public decimal Price { get; set; }
        public decimal ShellPrice { get; set; }
        public IQueryable<Response_VariantProperties_Product>? response_VariantProperties { get; set; }



    }
}
