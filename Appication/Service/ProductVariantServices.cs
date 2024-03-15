using Appication.PayLoads.Converter;
using Appication.PayLoads.DataResponse;
using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.Service
{
    public class ProductVariantServices : IProductVariantServices
    {
        private readonly IProductVariantRepositories _repo;
        private readonly ProductVariantWithVariantPropertiesConverter _coverter;

        public ProductVariantServices(IProductVariantRepositories repo, ProductVariantWithVariantPropertiesConverter coverter)
        {
            _repo = repo;
            _coverter = coverter;
        }

        public ResponseObject<DataResponse_ProductVariantsWithVariantProperties> GetProducVarianttById(int id)
        {
            var productvariant = _repo.GetProductVariantById(id);
            ResponseObject<DataResponse_ProductVariantsWithVariantProperties> res = new ResponseObject<DataResponse_ProductVariantsWithVariantProperties>();
            if (productvariant == null)
            {
                return res.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy biến thể sản phẩm", null);
            }
            return res.ResponseSuccess("Tìm thấy biến thể sản phẩm thành công", _coverter.EntityToDTO(productvariant));
        }
    }
}
