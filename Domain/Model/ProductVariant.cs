using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ProductVariant
    {
        [Key]
        public int VariantId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public string VariantName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ShellPrice { get; set; }
        public Product? product { get; set; }
        public IEnumerable<VariantProperty>? variantProperties { get; set; }
    }
}
