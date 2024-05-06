namespace RPRENTAL.ViewModels
{
    public class BarChartDTO
    {
        public List<ChartData> Series { get; set; }
        public string[] Categories { get; set; }
        public class ChartData
        {
            public string Name { get; set; }
            public int[] Data { get; set; }
        }


    }
}
