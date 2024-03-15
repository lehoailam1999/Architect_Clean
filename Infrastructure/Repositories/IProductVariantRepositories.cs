﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IProductVariantRepositories
    {
        ProductVariant GetProductVariantById(int id);
    }
}
