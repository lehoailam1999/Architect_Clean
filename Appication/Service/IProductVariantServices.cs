using Appication.PayLoads.DataResponse;
using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.Service
{
    public interface IProductVariantServices
    {
        ResponseObject<DataResponse_ProductVariantsWithVariantProperties> GetProducVarianttById(int id);

    }
}
