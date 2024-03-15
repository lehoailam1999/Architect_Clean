using Appication.PayLoads.Converter.SanPhamConverter;
using Appication.PayLoads.DataResponse.DataResponse_Product;
using Application.PayLoads.Converter;
using Application.PayLoads.DataRequest;
using Application.PayLoads.DataResponse;
using Application.PayLoads.Response;
using Domain.Model;
using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.Service
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProductRepositories _repo;
        private readonly ProductConverter _converter;
        private readonly ProductInformationConverter _converterInfo;
        
        public ProductServices(AppDbContext appDbContext,ProductConverter converter,IProductRepositories repo, ProductInformationConverter converterInfo)
        {
            _appDbContext = appDbContext;
            _repo = repo;
            _converter = converter;
            _converterInfo = converterInfo;
        }

        public ResponseObject<Response_Product> AddProduct(Request_Products requestpro)
        {
            ResponseObject<Response_Product> res = new ResponseObject<Response_Product>();

            Product p = new Product();
            p.ProductName = requestpro.ProductName;
            p.productVariants = EntityToDTOAddProductVariant(p.ProductId, requestpro.productVariants); ;
            _appDbContext.Products.Add(p);
            _appDbContext.SaveChanges();
            //Thêm ProductVariant
          /*  p.productVariants = EntityToDTOAddProductVariant(p.ProductId, requestpro.productVariants);
            _appDbContext.Products.Update(p);
            _appDbContext.SaveChanges();*/
            return res.ResponseSuccess("Thêm sản phẩm thành công", _converter.EntityToDTO(p)); ;
        }
        public List<ProductVariant> EntityToDTOAddProductVariant(int productid, List<Request_ProductVariants> requestpro)
        {
            var product = _appDbContext.ProductVariants.SingleOrDefault(x => x.ProductId == productid);
            if (product is null)
            {
                return null;
            }
            List<ProductVariant> list = new List<ProductVariant>();
            foreach (var item in requestpro)
            {
                ProductVariant pv = new ProductVariant();

                pv.ProductId = productid;
                pv.VariantName = item.VariantName;
                pv.Quantity = item.Quanlity;
                pv.Price = item.Price;
                pv.ShellPrice = item.ShellPrice;
                list.Add(pv);
            }
            _appDbContext.ProductVariants.AddRange(list);
            _appDbContext.SaveChanges();
            return list;

        }
        public ResponseObject<List<Response_Product>> GetAllProducts()
        {
            var litsproduct = _repo.GetAllProducts().ToList();
            ResponseObject<List<Response_Product>> listres = new ResponseObject<List<Response_Product>>();
            if (litsproduct.Count==0)
            {
                return listres.ResponseError(StatusCodes.Status404NotFound, "Lỗi", null);

            }
            return listres.ResponseSuccess("Tìm thấy sản phẩm thành công", _converter.EntityToListDTO(litsproduct));
        }

        public ResponseObject<List<Response_ProductInformation>> GetAllProductsInformation()
        {
            var litsproduct = _repo.GetAllProductInformation().ToList();
            ResponseObject<List<Response_ProductInformation>> listres = new ResponseObject<List<Response_ProductInformation>>();
            if (litsproduct.Count == 0)
            {
                return listres.ResponseError(StatusCodes.Status404NotFound, "Lỗi", null);
            }
            return listres.ResponseSuccess("Tìm thấy sản phẩm thành công", _converterInfo.AllEntityToDTO(litsproduct));
            
        }

        public ResponseObject<Response_Product> GetProductById(int id)
        {
           var product =_repo.GetProductById(id);
            ResponseObject<Response_Product> res = new ResponseObject<Response_Product>();
            if (product==null)
            {
                return res.ResponseError(StatusCodes.Status404NotFound, "Không tìm thấy sản phẩm", null);
            }
            return res.ResponseSuccess($"Tìm thấy sản phẩm có id là {id} thành công", _converter.EntityToDTO(product));
        }

        public ResponseObject<List<Response_Product>> GetProductWithPrice(decimal giadau, decimal giacuoi)
        {
           var products = _repo.GetProductWithPrice(giadau,giacuoi).ToList();
            ResponseObject<List<Response_Product>> listres = new ResponseObject<List<Response_Product>>();
            if (products==null)
            {
                return listres.ResponseError(StatusCodes.Status404NotFound, "Không có sản phẩm nào", null);
            }
            return listres.ResponseSuccess($"Danh sách san phẩm có giá đầu là {giadau} và giá cuối {giacuoi}", _converter.EntityToDTOWithPrice(products,giadau,giacuoi));
        }   

        public ResponseObject<List<Response_Product>> GetProductWithQuantity(int id)
        {
            var listproduct = _repo.GetProductWithQuantity(id).ToList();
            ResponseObject<List<Response_Product>> listres = new ResponseObject<List<Response_Product>>();
            if (listproduct.Count == 0)
            {
                return listres.ResponseError(StatusCodes.Status404NotFound, $"Không có sản phẩm nào có só lượng hơn {id}", null);

            }
            return listres.ResponseSuccess($"Tìm thấy sản phẩm có số lượng hơn {id} thành công", _converter.EntityToListDTOThanQuantity(listproduct,id));


        }
    }
}
