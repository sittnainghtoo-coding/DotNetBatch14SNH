using DotNetBatch14SNH_Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogAjaxController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [ActionName("Index")]
        public IActionResult BlogList()
        {
            

            return View("BlogList");
        }

        [ActionName("GetBlogs")]

        public IActionResult GetBlogs()
        {
            var result = _blogService.GetBlogs();
            return Json(result);
        }

		[ActionName("Create")]
		public IActionResult CreateBlog()
		{
			return View("CreateBlog");
		}

		[HttpPost]
        [ActionName("Save")]
        public IActionResult SaveBlog(BlogModel requestmodel)
        {
            var result = _blogService.CreateBlog(requestmodel);
            return RedirectToAction("Index");
        }

        [ActionName("Edit")]
        public IActionResult EditBlog(string id)
        {
            var item = _blogService.GetBlog(id);
            return View("EditBlog", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var result = _blogService.UpdateBlog(requestModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBlog(string id)
        {
            var result = _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }
    }
}
