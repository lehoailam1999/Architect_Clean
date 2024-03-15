using Appication.PayLoads.DataResponse.DataResponse_Product;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appication.PayLoads.Converter.SanPhamConverter
{
    public class DetailConverter
    {
        public List<Response_Details> EntityToDTO(List<PropertyDetail> propertyDetails)
        {
            List<Response_Details> list = new List<Response_Details>();
            foreach (var item in propertyDetails)
            {
                Response_Details response = new Response_Details()
                {
                    DetailName = item.DetailName
                };
                list.Add(response);
            }
            
            return list;
        }

    }
}
