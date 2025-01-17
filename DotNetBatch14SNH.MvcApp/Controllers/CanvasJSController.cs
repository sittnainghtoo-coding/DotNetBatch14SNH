using DotNetBatch14SNH.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.MvcApp.Controllers
{
    public class CanvasJSController : Controller
    {
        public IActionResult AreaCanvasJs()
        {
            var model = new AreaCanvasJsModel
            {
                Categories = new string[] { "Q1", "Q2", "Q3" },
                Data = new double[] { 5.0, 7.5, 6.0 }
            };
            return View(model);
        }
    }
}
