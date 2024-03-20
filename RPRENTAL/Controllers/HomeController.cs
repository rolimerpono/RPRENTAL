using Common;
using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using RPRENTAL.Models;
using RPRENTAL.ViewModels;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace RPRENTAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly iWorker _iWorker;

        public HomeController(ILogger<HomeController> logger,iWorker worker)
        {
            _logger = logger;
            _iWorker = worker;
        }

        public IActionResult Index()
        {
            HomeVM  objHomeVM = new HomeVM()
            {
                ROOM_LIST = _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES"),
                NO_OF_STAY = 1,
                CHECKIN_DATE = DateOnly.FromDateTime(DateTime.Now)
            };
            
            return View(objHomeVM);
        }

    


        [HttpPost]
        public IActionResult GetRoomAvailable(DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE)
        {

            Util objUtil = new Util(_iWorker);



            var objRoomList = _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES").ToList();
            foreach (var roomItem in objRoomList)
            {
                int iCounter = objUtil.GetRoomsAvailableCount(roomItem.ROOM_ID, CHECKIN_DATE, CHECKOUT_DATE);

                roomItem.IS_ROOM_AVAILABLE = iCounter > 0 ? true : false;
            }

            HomeVM objHomeVM = new()
            {
                CHECKIN_DATE = CHECKIN_DATE,
                CHECKOUT_DATE = CHECKOUT_DATE,
                ROOM_LIST = objRoomList               

            };
            return PartialView("Common/_RoomList", objHomeVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
