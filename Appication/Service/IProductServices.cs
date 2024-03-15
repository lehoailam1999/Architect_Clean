using Appication.PayLoads.DataResponse.DataResponse_Product;
using Application.PayLoads.DataRequest;
using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using Domain.Model;
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
        ResponseObject<List<Response_Product>> GetAllProducts();
        ResponseObject<List<Response_ProductInformation>> GetAllProductsInformation();
        ResponseObject<List<Response_Product>> GetProductWithQuantity(int id);
        ResponseObject<List<Response_Product>> GetProductWithPrice(decimal giadau, decimal giacuoi);
        ResponseObject<Response_Product> AddProduct(Request_Products requestpr);



    }
}
