using Common;
using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using RPRENTAL.Models;
using RPRENTAL.ViewModels;
using System.ComponentModel.Design;
using System.Diagnostics;

using Model;


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

        #region OLD INDEX
        public IActionResult Index(int? iPage)
        {

            int pageNumber = iPage ?? 1;
            int pageSize = 6; 

            var objRooms = _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES").AsQueryable();
        

            return View(PaginatedList<Room>.Create(objRooms, pageNumber,pageSize));
        }
        #endregion

      
        [HttpPost]
        public IActionResult GetRoomAvailable(DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE, int? iPage)
        {

            Util objUtil = new Util(_iWorker);


            IEnumerable<Room> objRooms = _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES");

            List<Room> objRoomList = new List<Room>();
            foreach (var roomItem in objRooms)
            {
                int iCounter = objUtil.GetRoomsAvailableCount(roomItem.ROOM_ID, CHECKIN_DATE, CHECKOUT_DATE);            

                Room objRoom = new Room
                {
                    ROOM_ID = roomItem.ROOM_ID,
                    ROOM_NAME = roomItem.ROOM_NAME,
                    DESCRIPTION = roomItem.DESCRIPTION,
                    ROOM_PRICE = roomItem.ROOM_PRICE,
                    ROOM_AMENITIES = roomItem.ROOM_AMENITIES,
                    MAX_OCCUPANCY = roomItem.MAX_OCCUPANCY,
                    IS_ROOM_AVAILABLE = roomItem.IS_ROOM_AVAILABLE = iCounter > 0 ? true : false,
                    IMAGE_URL = roomItem.IMAGE_URL,
                    CHECKIN_DATE = CHECKIN_DATE,
                    CHECKOUT_DATE = CHECKOUT_DATE
                };

              
                objRoomList.Add(objRoom);
            }

            int pageNumber = iPage ?? 1; 
            int pageSize = 6;
           
            return PartialView("Common/_RoomList",PaginatedList<Room>.Create(objRoomList.AsQueryable(), pageNumber, pageSize));
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
