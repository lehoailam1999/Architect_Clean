using Appication.PayLoads.Converter.SanPhamConverter;
using Application.PayLoads.Converter;
using Application.PayLoads.DataRequest;
using Application.PayLoads.DataResponse;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PayLoads.Converter
{
    public class ProductConverter
    {
        private readonly AppDbContext _appDbContext;
        private readonly ProductVariantsConverter _converter;

        public ProductConverter(AppDbContext appDbContext, ProductVariantsConverter converter)
        {
            _appDbContext = appDbContext;
            _converter = converter;
        }

        public Response_Product EntityToDTO(Product p)
        {
            Response_Product response= new Response_Product()
            {
                ProductName = p.ProductName,
            };
            if (p.ProductId!=null)
            {
                var pr = _appDbContext.ProductVariants.Where(x => x.ProductId == p.ProductId);
                if (pr!=null)
                {
                    response.productVariants = pr.Select(x => _converter.EntityToDTO(x));
                }
            }
            return response;
        }
        /*public Response_Product EntityToDTOAddProduct(Request_Products requestpro)
        {
            Product p = new Product();
            p.ProductName = requestpro.ProductName;
            p.productVariants = null;
            _appDbContext.Products.Add(p);
            _appDbContext.SaveChanges();
            //Thêm ProductVariant
            p.productVariants = EntityToDTOAddProductVariant(p.ProductId, requestpro.productVariants);
            _appDbContext.Products.Update(p);
            _appDbContext.SaveChanges();
            return p;
        }
        public List<ProductVariant> EntityToDTOAddProductVariant(int productid,List<Request_ProductVariants> requestpro)
        {
            var product = _appDbContext.ProductVariants.SingleOrDefault(x => x.ProductId == productid);
            if (product is null)
            {
                return null;
            }
            List<ProductVariant> list = new List<ProductVariant>();
            foreach (var item in requestpro)
            {
                ProductVariant pv = new ProductVariant()
                { 
                    VariantName = item.VariantName,
                    Quantity = item.Quanlity,
                    Price = item.Price,
                    ShellPrice = item.ShellPrice
                };
                list.Add(pv);
            }
            _appDbContext.ProductVariants.AddRange(list);
            _appDbContext.SaveChanges();
            return requestpro;

        }*/


        public List<Response_Product> EntityToListDTO(List<Product> listp)
        {
            List<Response_Product> list = new List<Response_Product>();

            foreach (var item in listp)
            {
                Response_Product response = new Response_Product() 
                {
                    ProductName=item.ProductName
                };
                if (item.ProductId != null)
                {
                    var pr = _appDbContext.ProductVariants.Where(x => x.ProductId == item.ProductId).AsQueryable();
                    if (pr != null)
                    {
                        response.productVariants = pr.Select(x => _converter.EntityToDTO(x)).AsQueryable();
                    }
                }
                list.Add(response);

            }
            return list;
        }
        public List<Response_Product> EntityToListDTOThanQuantity(List<Product> listp,int id)
        {
            List<Response_Product> list = new List<Response_Product>();

            foreach (var item in listp)
            {
                Response_Product response = new Response_Product()
                {
                    ProductName = item.ProductName
                };
                if (item.ProductId != null)
                {
                    var pr = _appDbContext.ProductVariants.Where(x => x.Quantity >id).AsQueryable();
                    if (pr != null)
                    {
                        response.productVariants = pr.Select(x => _converter.EntityToDTO(x)).AsQueryable();
                    }
                }
                list.Add(response);

            }
            return list;
        }
        public List<Response_Product> EntityToDTOWithPrice(List<Product> listp,decimal giadau,decimal giacuoi)
        {
            List<Response_Product> list = new List<Response_Product>();
            foreach (var item in listp)
            {
                Response_Product response = new Response_Product()
                {
                    ProductName = item.ProductName
                };
                if (item.ProductId != null)
                {
                    var pr = _appDbContext.ProductVariants.Where(x => x.Price > giadau && x.Price < giacuoi).ToList();
                    if (pr!=null)
                    {
                        response.productVariants = pr.Select(x => _converter.EntityToDTO(x)).AsQueryable();
                    }
                }
                list.Add(response);

            }
            return list;
        }
    }
}
