using Application.PayLoads.DataRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.DataResponse
{
    public  class Response_Product
    {
        public string ProductName { get; set; }
        public IQueryable<Response_ProductVariants>? productVariants { get; set; }
    }
}
