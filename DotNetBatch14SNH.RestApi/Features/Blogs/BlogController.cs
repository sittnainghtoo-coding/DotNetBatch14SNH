using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.RestApi.Features.Blogs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController()
        {
            _blogService = new BlogService();
        }

        [HttpGet]
        public IActionResult GetBlogs() 
        {
            var model = _blogService.GetBlogs();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(string id)
        {
            var model = _blogService.GetBlog(id);
            if(model is null)
            {
                return NotFound("No data Found");
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogModel requestModel)
        {
            var model = _blogService.CreateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPut]
        public IActionResult UpdateBlog()
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var model = _blogService.UpdateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult DeleteBlog() 
        {
            return Ok();
        }
    }
}
