using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.DataResponse
{
    public class Response_ProductVariants
    {
        public string VariantName { get; set; }
        public int Quanlity { get; set; }
        public decimal Price { get; set; }
        public decimal ShellPrice { get; set; }
    }
}
