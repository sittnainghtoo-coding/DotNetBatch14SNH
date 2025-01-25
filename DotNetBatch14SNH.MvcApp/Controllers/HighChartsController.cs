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
                new double[] { 2.8, 3.0 },
                new double[] { 2.4, 3.3 },
                new double[] { 2.2, 3.5 },
                new double[] { 3.0, 2.8 },
            }
            };
            return View(model);
        }

        public IActionResult LineHighChart()
        {
            var model = new LineHighChartModel
            {
                Labels = new string[] { "January", "February", "March", "April", "May" },
                Dataset1 = new double[] { 10, 15, 20, 25, 30 },
                Dataset2 = new double[] { 5, 10, 15, 20, 25 }
            };
            return View(model);
        }


    }
}
