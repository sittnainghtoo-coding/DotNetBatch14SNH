using DotNetBatch14SNH.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14SNH.MvcApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult PieChart()
        {
            PieChartModel model = new PieChartModel
            {
                Series = new int[] { 44, 55, 13, 43, 22 },
                Labels = new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" }
            };
            return View(model);
        }

        public IActionResult LineChart()
        {
            LineChartModel model = new LineChartModel
            {
                Series = new int[] { 10, 41, 35, 51, 49, 62, 69, 91, 148 },
                Labels = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep" }
            };
            return View(model);
        }

        public IActionResult FunnelChart(string chartType = "pie")
        {
            FunnelChartModel model = new FunnelChartModel();

            if (chartType == "pie")
            {
                model.Series = new int[] { 44, 55, 13, 43, 22 };
                model.Labels = new string[] { "Team A", "Team B", "Team C", "Team D", "Team E" };
                model.ChartType = "pie";
            }
            else if (chartType == "funnel")
            {
                model.FunnelData = new int[] { 1380, 1100, 990, 880, 740, 548, 330, 200 };
                model.FunnelCategories = new string[]
                {
            "Sourced",
            "Screened",
            "Assessed",
            "HR Interview",
            "Technical",
            "Verify",
            "Offered",
            "Hired"
                };
                model.ChartType = "funnel";
            }

            return View(model);
        }


    }
}
