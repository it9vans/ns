using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using Server.Services.ServiceInterfaces;
using Shared;


namespace Server.Controllers
{


    public class ProductController : Controller
    {
        IProductService _IProductService;

        public ProductController(IProductService iProductService)
        {
            _IProductService = iProductService;
        }

        [HttpGet]
        [Route("/products")]
        public ActionResult<List<ProductDTO>> Index()
        {
            var result = _IProductService.GetProducts();
            return Ok(result);
        }

        [HttpGet]
        [Route("/products/check")]
        public ActionResult<int> GetCheck()
        {
            var result = _IProductService.GetProducts();
            int check = result.Count();
            return Ok(check);
        }
    }
}
