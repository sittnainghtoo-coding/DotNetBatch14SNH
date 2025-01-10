using DotNetBatch14SNH_Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.RestApi2.Features
{
    [Route("api/[controller]")] //endpoint
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController()
        {
            _blogService = new BlogEFCoreService();
        }

        [HttpGet] //attribute
        public IActionResult GetBlogs()
        {
            try
            {
                var lst = _blogService.GetBlogs();
                //throw new Exception("Helll");
                BlogListResponseModel model = new BlogListResponseModel()
                {
                    IsSuccess = true,
                    Data = lst,
                    Message = "Success"

                }; 
                
                return Ok(model);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString(),
                });
            }
            
        }

        [HttpGet("{id}")] //attribute
        public IActionResult GetBlog(string id)
        {
            try
            {
                var model = _blogService.GetBlog(id);
                if (model is null)
                {
                    return NotFound(new BlogListResponseModel
                    {
                        Message = "no data found"
                    });
                }
                return Ok(new BlogResponseModel
                {
                    Message = "Success",
                    IsSuccess = true,
                    Data = model
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString()
                });
               
            }
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogModel requestModel)
        {
            try
            {
                var model = _blogService.CreateBlog(requestModel);
                if (!model.IsSuccess)
                {
                    return BadRequest(model);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BlogResponseModel
                {
                    Message = ex.ToString(),
                });
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpsertBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;

            var model = _blogService.UpdateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var model = _blogService.UpdateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(string id, BlogModel requestModel)
        {

            try
            {
                requestModel.BlogId = id;
                var model = _blogService.DeleteBlog(id);
                if (!model.IsSuccess)
                {
                    return BadRequest(model);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new BlogListResponseModel
                {
                    Message = ex.ToString()
                });
            }
        }
    }
}
