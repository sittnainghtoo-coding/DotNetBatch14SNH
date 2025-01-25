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

        // Controller
        public IActionResult FloatingBarChartJS()
        {
            FloatingBarChartJSModel model = new FloatingBarChartJSModel
            {
                Data = new List<FloatingBarDataset>
        {
            new FloatingBarDataset
            {
                Label = "Dataset 1",
                Data = new List<BarRange>
                {
                    new BarRange { Min = -3, Max = 3 },
                    new BarRange { Min = -6, Max = -2 },
                    new BarRange { Min = -8, Max = -4 },
                    new BarRange { Min = -5, Max = -1 }
                },
                BackgroundColor = "rgba(75, 192, 192, 0.2)",
                BorderColor = "rgba(75, 192, 192, 1)"
            }
        },
                Labels = new string[] { "Group 1", "Group 2", "Group 3", "Group 4" }
            };

            return View(model);
        }

    }
}
