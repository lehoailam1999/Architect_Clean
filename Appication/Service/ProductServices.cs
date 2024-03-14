using Application.PayLoads.Converter;
using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;

namespace Application.Service
{
    public class ProductServices : IProductServices
    {
        private readonly ProductRepositories _repo;
        private readonly ProductConverter _converter;
        public ProductServices()
        {

        }
        public ProductServices(ProductConverter converter,ProductRepositories productRepositories)
        {
            _repo = productRepositories;
            _converter = converter;
        }

        public ResponseObject<Response_Product> GetProductById(int id)
        {
           var product =_repo.GetProductById(id);
            ResponseObject<Response_Product> res = new ResponseObject<Response_Product>();
            if (product==null)
            {
                return res.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm", null);
            }
            return res.ResponseSuccess("Tìm thấy sản phẩm thành công", _converter.EntityToDTO(product));
        }
    }
}
