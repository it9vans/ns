using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Server.Services.ServiceInterfaces;
using Shared;


namespace Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        //[Route("products")]
        //[HttpGet]
        IProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public ActionResult<List<ProductDTO>> Index()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }

        [HttpGet]
        [Route("/check")]
        public ActionResult<int> GetCheck()
        {
            var result = _productService.GetProducts();
            int check = result.Count();
            return Ok(2);
        }
    }
}
