using Common;
using DataService.Interface;
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

            var objRoomList = _iWorker.tbl_Rooms
             .GetAll(IncludeProperties: "ROOM_AMENITIES")
             .Select(roomItem => new HomeVM
             {
                 ROOM_ID = roomItem.ROOM_ID,
                 ROOM_NAME = roomItem.ROOM_NAME,
                 DESCRIPTION = roomItem.DESCRIPTION,
                 ROOM_PRICE = roomItem.ROOM_PRICE,
                 ROOM_AMENITIES = roomItem.ROOM_AMENITIES?.Select(item => new RoomAmenity
                 {
                     ID= item.ID,
                     ROOM_ID = item.ROOM_ID,
                     AMENITY_ID = item.AMENITY_ID,
                     AMENITY_NAME = _iWorker.tbl_Amenity.Get(fw => fw.AMENITY_ID == item.AMENITY_ID)?.AMENITY_NAME,
                     ROOMS = item.ROOMS
                 }).ToList(),
                 MAX_OCCUPANCY = roomItem.MAX_OCCUPANCY,
                 IMAGE_URL = roomItem.IMAGE_URL
             }).ToList();

            return View("Index", PaginatedList<HomeVM>.Create(objRoomList.AsQueryable(), pageNumber, pageSize));
        }
           

        [HttpPost]
        public IActionResult GetRoomAvailable(DateOnly CHECKIN_DATE, DateOnly CHECKOUT_DATE, int? iPage)
        {
            var objRoomList = _iWorker.tbl_Rooms
                .GetAll(IncludeProperties: "ROOM_AMENITIES")
                .AsEnumerable() // Load into memory to perform further operations
                .Select(roomItem =>
                {
                    var iCounter = new Util(_iWorker).GetRoomsAvailableCount(roomItem.ROOM_ID, CHECKIN_DATE, CHECKOUT_DATE);

                    return new HomeVM
                    {
                        ROOM_ID = roomItem.ROOM_ID,
                        ROOM_NAME = roomItem.ROOM_NAME,
                        DESCRIPTION = roomItem.DESCRIPTION,
                        ROOM_PRICE = roomItem.ROOM_PRICE,
                        ROOM_AMENITIES = roomItem.ROOM_AMENITIES.Select(item => new RoomAmenity
                        {
                            ID = item.ID,
                            ROOM_ID = item.ROOM_ID,
                            AMENITY_ID = item.AMENITY_ID,
                            AMENITY_NAME = _iWorker.tbl_Amenity.Get(fw => fw.AMENITY_ID == item.AMENITY_ID).AMENITY_NAME,
                            ROOMS = item.ROOMS
                        }).ToList(),

                        MAX_OCCUPANCY = roomItem.MAX_OCCUPANCY,
                        IS_ROOM_AVAILABLE = iCounter > 0 ? true : false,
                        IMAGE_URL = roomItem.IMAGE_URL,
                        CHECKIN_DATE = CHECKIN_DATE,
                        CHECKOUT_DATE = CHECKOUT_DATE
                    };
                }).ToList();

            return PartialView("Common/_RoomList", GetPaginatedRoomList(iPage, objRoomList.AsQueryable()));
        }

        private PaginatedList<HomeVM> GetPaginatedRoomList(int? pageNumber, IQueryable<HomeVM> source = null)
        {
            var pageSize = 6;       
            return PaginatedList<HomeVM>.Create(source.AsQueryable(), pageNumber ?? 1, pageSize);
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
