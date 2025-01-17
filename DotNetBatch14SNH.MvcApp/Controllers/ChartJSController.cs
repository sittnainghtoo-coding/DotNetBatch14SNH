using DotNetBatch14SNH.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.MvcApp.Controllers
{
    public class ChartJSController : Controller
    {
        public IActionResult RadarChartJS()
        {
            RadarChartJSModel model = new RadarChartJSModel
            {
                Series = new int[] { 20, 10, 4, 2, 8, 5 },
                Labels = new string[] { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" }
            };
            return View(model);
        }
    }
}
