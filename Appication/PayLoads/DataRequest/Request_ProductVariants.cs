using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.DataRequest
{
    public class Request_ProductVariants
    {
        public string VariantName { get; set; }
        public int Quanlity { get; set; }
        public decimal Price { get; set; }
        public decimal ShellPrice { get; set; }
    }
}
