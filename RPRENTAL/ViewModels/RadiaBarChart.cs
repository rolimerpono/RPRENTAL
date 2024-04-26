namespace RPRENTAL.ViewModels
{
    public class RadiaBarChart
    {
        public decimal TotalCount { get; set; }
        public decimal CountInCurrentMonth { get; set; }

        public bool HasRationIncreased { get; set; }

        public int[] Series { get; set; }


    }
}
