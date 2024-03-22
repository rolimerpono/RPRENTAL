using Common;
using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;
using RPRENTAL.Models;
using RPRENTAL.ViewModels;
using System.Diagnostics;
using System.Linq;

namespace RPRENTAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorker _iWorker;

        public HomeController(ILogger<HomeController> logger, IWorker worker)
        {
            _logger = logger;
            _iWorker = worker;
        }

        public IActionResult Index(int? iPage)
        {
            var pageNumber = iPage ?? 1;
            var pageSize = 6;

            var objRooms = _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES").AsQueryable();

            return View("Index", PaginatedList<Room>.Create(objRooms, pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult PageList(int? iPage)
        {
            return PartialView("Common/_RoomList", GetPaginatedRoomList(iPage));
        }

        [HttpPost]
        public IActionResult GetRoomAvailable(DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE, int? iPage)
        {
            var objRoomList = _iWorker.tbl_Rooms
                .GetAll(includeProperties: "ROOM_AMENITIES")
                .AsEnumerable() // Load into memory to perform further operations
                .Select(roomItem =>
                {
                    var iCounter = new Util(_iWorker).GetRoomsAvailableCount(roomItem.ROOM_ID, CHECKIN_DATE, CHECKOUT_DATE);

                    return new Room
                    {
                        ROOM_ID = roomItem.ROOM_ID,
                        ROOM_NAME = roomItem.ROOM_NAME,
                        DESCRIPTION = roomItem.DESCRIPTION,
                        ROOM_PRICE = roomItem.ROOM_PRICE,
                        ROOM_AMENITIES = roomItem.ROOM_AMENITIES,
                        MAX_OCCUPANCY = roomItem.MAX_OCCUPANCY,
                        IS_ROOM_AVAILABLE = iCounter > 0,
                        IMAGE_URL = roomItem.IMAGE_URL,
                        CHECKIN_DATE = CHECKIN_DATE,
                        CHECKOUT_DATE = CHECKOUT_DATE
                    };
                }).ToList();

            return PartialView("Common/_RoomList", GetPaginatedRoomList(iPage, objRoomList.AsQueryable()));
        }

        private PaginatedList<Room> GetPaginatedRoomList(int? pageNumber, IQueryable<Room> source = null)
        {
            var pageSize = 6;
            source ??= _iWorker.tbl_Rooms.GetAll(includeProperties: "ROOM_AMENITIES").AsQueryable();
            return PaginatedList<Room>.Create(source, pageNumber ?? 1, pageSize);
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
