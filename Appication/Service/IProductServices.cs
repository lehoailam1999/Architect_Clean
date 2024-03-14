using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IProductServices
    {
        ResponseObject<Response_Product> GetProductById(int id);

    }
}
