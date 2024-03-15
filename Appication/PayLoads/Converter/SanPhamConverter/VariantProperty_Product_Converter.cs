using Appication.PayLoads.DataResponse.DataResponse_Product;
using Application.PayLoads.Converter;
using Application.PayLoads.DataResponse;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.Converter.SanPhamConverter
{
    public class VariantProperty_Product_Converter
    {
        private readonly AppDbContext _appDbContext;
        private readonly DetailConverter _converter;
        public VariantProperty_Product_Converter(AppDbContext appDbContext, DetailConverter converter)
        {
            _appDbContext = appDbContext;
            _converter = converter;
        }
        public List<Response_VariantProperties_Product> EntityToDTO(List<VariantProperty> variant)
        {
            List<Response_VariantProperties_Product> list = new List<Response_VariantProperties_Product>();
            foreach (var item in variant)
            {
                Response_VariantProperties_Product response = new Response_VariantProperties_Product()
                {
                    PropertyName = item.PropertyName,
                };
                if (item.PropertyId != null)
                {
                    var propertyDetails = _appDbContext.PropertyDetails.Where(x => x.PropertyId == item.PropertyId).ToList();
                    if (propertyDetails != null)
                    {
                        response.response_Details = _converter.EntityToDTO(propertyDetails).AsQueryable();
                    }
                };
                list.Add(response);
            }
            
            return list;
        }
    }
}
