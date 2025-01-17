using DotNetBatch14SNH_Shared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.MvcApp.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [ActionName("Index")]
        public IActionResult BlogList()
        {
            var lst = _blogService.GetBlogs();

            return View("BlogList",lst);
        }

        [ActionName("Create")]

        public IActionResult CreateBlog()
        {
            return View("CreateBlog",new BlogModel());
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
        
        [ActionName("Delete")]
        public IActionResult DeleteBlog(string id)
        {
            var result = _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }
    }
}
