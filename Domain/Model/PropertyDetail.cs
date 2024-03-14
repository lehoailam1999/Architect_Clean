﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PropertyDetail
    {
        [Key]
        public int DetailId { get; set; }
        public int PropertyId { get; set; }
        public string DetailName { get; set; }
        public VariantProperty? variantProperty { get; set; }
    }
}
