using DotNetBatch14SNH.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.MvcApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult ScatterHighChart()
        {
            var model = new ScatterHighChartModel
            {
                Data = new double[][] {
                new double[] { 1.5, 2.3 },
                new double[] { 2.0, 1.8 },
                new double[] { 2.8, 3.0 }
            }
            };
            return View(model);
        }
    }
}
