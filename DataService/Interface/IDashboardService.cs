using RPRENTAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataService.Interface
{
    public interface IDashboardService
    {

        Task<RadialBarChartDTO> GetTotalBookingRadialChartData();
        Task<RadialBarChartDTO> GetRegisteredUserRadialChartData();
        Task<RadialBarChartDTO> GetRevenueRadialChartData();
        Task<PieChartDTO> GetCustomerBookingPieChart();
        Task<BarChartDTO> GetMemberAndBookingBarChartData();
        Task<PieChartDTO> GetOverAllBokingsPieChartData();
    }
}
