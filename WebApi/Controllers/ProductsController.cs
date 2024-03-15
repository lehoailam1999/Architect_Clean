using Application.PayLoads.DataRequest;
using Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _service;

        public ProductsController(IProductServices service)
        {
            _service = service;
        }
        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_service.GetProductById(id));
        }
        [HttpGet("GetAllProduct")]

        public IActionResult GetAllProduct()
        {
            return Ok(_service.GetAllProducts());
        }
        [HttpGet("GetAllProductWithQuantity")]
        public IActionResult GetAllProductWithQuantity(int id)
        {
            return Ok(_service.GetProductWithQuantity(id));
        }
        [HttpGet("GetAllProductWithPrice")]
        public IActionResult GetAllProductWithPrice(decimal giadau,decimal giacuoi)
        {
            return Ok(_service.GetProductWithPrice(giadau,giacuoi));
        }
        [HttpGet("GetAllProductInformation")]
        public IActionResult GetAllProductInformation()
        {
            return Ok(_service.GetAllProductsInformation());
        }
        [HttpPost]
        public IActionResult AddProduct(Request_Products p)
        {
            return Ok(_service.AddProduct(p));
        }
    }
}
