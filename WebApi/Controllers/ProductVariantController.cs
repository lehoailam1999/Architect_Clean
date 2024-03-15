using Appication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IProductVariantServices _service;

        public ProductVariantController(IProductVariantServices service)
        {
            _service = service;
        }
        [HttpGet("Bai5")]
        public IActionResult GetProductVariantById(int id)
        {
            return Ok(_service.GetProducVarianttById(id));
        }
    }
}
