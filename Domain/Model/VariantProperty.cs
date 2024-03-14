using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class VariantProperty
    {
        [Key]
        public int PropertyId { get; set; }
        [ForeignKey("VariantId")]
        public int VariantId { get; set; }
        public string PropertyName { get; set; }
        public ProductVariant? productVariant { get; set; }
        public IEnumerable<PropertyDetail>? propertyDetails { get; set; }
    }
}
