using Application.PayLoads.DataResponse;
using Application.PayLoads.DataResponse.DataResponse_Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.DataResponse.DataResponse_Product
{
    public class Response_ProductInformation
    {
        public string ProductName { get; set; }
        public IQueryable<Response_ProductVariants_Product>? productVariants { get; set; }
    }
}
