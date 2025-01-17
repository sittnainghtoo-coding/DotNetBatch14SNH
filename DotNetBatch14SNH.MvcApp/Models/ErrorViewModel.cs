namespace DotNetBatch14SNH.MvcApp.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    //ApexChat
    public class PieChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }

    }

    public class LineChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    //ChartJs
    public class RadarChartJSModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    //CanvasJs
    public class AreaCanvasJsModel
    {
        public string[] Categories { get; set; }
        public double[] Data { get; set; }
    }

    //HighChartJs
    public class ScatterHighChartModel
    {
        public double[][] Data { get; set; }
    }



}
