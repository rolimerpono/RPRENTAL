using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RPRENTAL.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {

        private readonly IDashboardService _IDashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _IDashboardService = dashboardService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> GetCustomerBookingPieChart()
        {
            return Json(await _IDashboardService.GetCustomerBookingPieChart());
        }

        public async Task<IActionResult> GetMemberAndBookingBarChartData()
        {
            return Json(await _IDashboardService.GetMemberAndBookingBarChartData());
        }

        public async Task<IActionResult> GetRegisteredUserChartData()
        {

            return Json(await _IDashboardService.GetRegisteredUserRadialChartData());
        }

        public async Task<IActionResult> GetRevenueChartData()
        {
            return Json(await _IDashboardService.GetRevenueRadialChartData());
        }

        public async Task<IActionResult> GetTotalBookingRadialChartData()
        {
            return Json(await _IDashboardService.GetTotalBookingRadialChartData());
        }

        public async Task<IActionResult> GetOverAllBookingPieChartData()
        { 
            return Json(await _IDashboardService.GetOverAllBokingsPieChartData());
        }

    }
}
