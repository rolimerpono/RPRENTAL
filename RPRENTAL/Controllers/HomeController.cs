using Common;
using DataService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Model;
using RPRENTAL.Models;
using RPRENTAL.ViewModels;
using Utility;
using System.Diagnostics;
using System.Linq;

namespace RPRENTAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorker _iWorker;
        private readonly IHelper _helper;
        private readonly ICompositeViewEngine _viewEngine;
        public HomeController(ILogger<HomeController> logger, IWorker worker, IHelper helper, ICompositeViewEngine viewengine)
        {
            _logger = logger;
            _iWorker = worker;
            _helper = helper;
            _viewEngine= viewengine;
        }

        public IActionResult Index(int? iPage)
        {

            var pageNumber = iPage ?? 1;
            var pageSize = 6;

            var objRoomList = _iWorker.tbl_Rooms
             .GetAll(IncludeProperties: "RoomAmenities")
             .Select(room_item => new HomeVM
             {
                 RoomId = room_item.RoomId,
                 RoomName = room_item.RoomName,
                 Description = room_item.Description,
                 RoomPrice = room_item.RoomPrice,
                 RoomAmenities = room_item.RoomAmenities?.Select(item => new RoomAmenity
                 {
                     Id= item.Id,
                     RoomId = item.RoomId,
                     AmenityId = item.AmenityId,
                     Amenity = _iWorker.tbl_Amenity.Get(fw => fw.AmenityId == item.AmenityId),
                     Room = item.Room
                 }).ToList(),
                 MaxOccupancy = room_item.MaxOccupancy,
                 ImageUrl = room_item.ImageUrl,
             }).ToList();

            return View("Index", PaginatedList<HomeVM>.Create(objRoomList.AsQueryable(), pageNumber, pageSize));
        }
           


        [HttpGet]    
        public IActionResult GetRoomAvailable(DateOnly CheckinDate, DateOnly CheckoutDate, int? iPage)
        {
            
            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);

            try
            {

                if ((CheckoutDate < CheckinDate || CheckinDate <= dateToday) && iPage == null)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.DateRange });
                }

                var objRoomList = _iWorker.tbl_Rooms
                    .GetAll(IncludeProperties: "RoomAmenities")
                    .AsEnumerable()
                    .Select(room_item =>
                    {
                        var iCounter = new Util(_iWorker).GetRoomsAvailableCount(room_item.RoomId, CheckinDate, CheckoutDate);

                        return new HomeVM
                        {
                            RoomId = room_item.RoomId,
                            RoomName = room_item.RoomName,
                            Description = room_item.Description,
                            RoomPrice = room_item.RoomPrice,
                            RoomAmenities = room_item.RoomAmenities.Select(item => new RoomAmenity
                            {
                                Id = item.Id,
                                RoomId = item.RoomId,
                                AmenityId = item.AmenityId,
                                Amenity = _iWorker.tbl_Amenity.Get(fw => fw.AmenityId == item.AmenityId),
                                Room = item.Room
                            }).ToList(),

                            MaxOccupancy = room_item.MaxOccupancy,
                            IsRoomAvailable = iCounter > 0 ? true : false,
                            ImageUrl = room_item.ImageUrl,
                            CheckinDate = CheckinDate,
                            CheckoutDate = CheckoutDate
                        };
                    }).ToList();

                PartialViewResult pvr = PartialView("Common/_RoomList", GetPaginatedRoomList(iPage, objRoomList.AsQueryable()));
                string html_result = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

                return Json(new { success = true, message = "", htmlContent = html_result });
              
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin});
            }
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
