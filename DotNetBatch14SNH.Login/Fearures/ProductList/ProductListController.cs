using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.Login.Fearures.ProductList
{
    [Route("api/product")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        private readonly ProductListService _productListService;
        public ProductListController(ProductListService productListService)
        {
            _productListService = productListService;
        }

        [HttpGet]
        public IActionResult Execute()
        {
            var reponse = _productListService.Execute();

            return Ok(reponse);
        }
    }
}
