using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.DataResponse
{
    public class DataResponse_ProductVariantsWithVariantProperties
    {
        public string ProductName { get; set; }
        public string VariantName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ShellPrice { get; set; }
        public IQueryable<Response_VariantProperties>? variantProperties { get; set; }
    }
}
