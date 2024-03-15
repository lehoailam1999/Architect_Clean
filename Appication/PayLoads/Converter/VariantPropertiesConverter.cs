using Appication.PayLoads.DataResponse;
using Application.PayLoads.DataResponse;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.Converter
{
    public class VariantPropertiesConverter
    {
        public Response_VariantProperties EntityToDTO(VariantProperty pt)
        {
            Response_VariantProperties response = new Response_VariantProperties()
            {
               PropertyName=pt.PropertyName
            };
            return response;
        }
    }
}
