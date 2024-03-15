using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.DataResponse.DataResponse_Product
{
    public class Response_VariantProperties_Product
    {
        public string PropertyName { get; set; }
        public IQueryable<Response_Details>? response_Details { get; set; }

    }

}
