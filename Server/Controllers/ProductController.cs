using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Server.Services.ServiceInterfaces;
using Shared;


namespace Server.Controllers
{

    [ApiController]
    public class ProductController : Controller
    {
        ////[Route("products")]
        ////[HttpGet]
        IProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("/products")]
        public ActionResult<List<ProductDTO>> GetProductListWithCategory()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }

        [Route("/check")]
        [HttpGet]
        //[Route("/check")]
        public ActionResult<int> GetCheck()
        {
            var result = _productService.GetProducts();
            int check = result.Count();
            return Ok(2);
        }
    }
}
