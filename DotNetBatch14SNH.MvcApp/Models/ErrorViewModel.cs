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

    public class FunnelChartModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
        public int[] FunnelData { get; set; }
        public string[] FunnelCategories { get; set; }
        public string ChartType { get; set; } // "pie" or "funnel"
    }

    //ChartJs
    public class RadarChartJSModel
    {
        public int[] Series { get; set; }
        public string[] Labels { get; set; }
    }

    // Model
    public class FloatingBarChartJSModel
    {
        public IEnumerable<FloatingBarDataset> Data { get; set; }
        public string[] Labels { get; set; }
    }

    public class FloatingBarDataset
    {
        public string Label { get; set; }
        public IEnumerable<BarRange> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
    }

    public class BarRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
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

    public class LineHighChartModel
    {
        public string[] Labels { get; set; }
        public double[] Dataset1 { get; set; }
        public double[] Dataset2 { get; set; }
    }





}
