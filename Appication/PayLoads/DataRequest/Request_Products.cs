using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.DataRequest
{
    public class Request_Products
    {
        public string ProductName { get; set; }
        public List<Request_ProductVariants>? productVariants { get; set; }
    }
}
