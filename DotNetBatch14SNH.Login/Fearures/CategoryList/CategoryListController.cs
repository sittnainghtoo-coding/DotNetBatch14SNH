using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.Login.Fearures.CategoryList
{
    [Route("api/category")]
    [ApiController]
    public class CategoryListController : ControllerBase
    {
        private readonly CategoryListService _service;
        public CategoryListController(CategoryListService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Execute()
        {
            var reponse = _service.Execute();

            return Ok(reponse);
        }
    }
}
