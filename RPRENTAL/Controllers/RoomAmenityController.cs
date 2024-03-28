using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Model;
using PayPal.Api;
using Repository.Interface;
using RPRENTAL.ViewModels;
using Stripe.Tax;

namespace RPRENTAL.Controllers
{
    public class RoomAmenityController : Controller
    {
        private readonly IRoomService _IRoomService;
        private readonly IAmenityOnlyService _IAmenityOnlyService;
        private readonly IRoomAmenityService _IRoomAmenityService;

        public RoomAmenityController(IRoomService iRoom, IAmenityOnlyService iAmenity, IRoomAmenityService iRoomAmenity)
        {
            _IRoomAmenityService =  iRoomAmenity;
            _IAmenityOnlyService = iAmenity;
            _IRoomService = iRoom;
        }
        public IActionResult Index()
        {
         
            var objAmenityList = _IAmenityOnlyService.GetAll();

            var objRoomAmenities = _IRoomService.GetAll()
             .GroupJoin(
                 _IRoomAmenityService.GetAll(),
                 room => room.ROOM_ID,
                 roomAmenity => roomAmenity.ROOM_ID,
                 (room, roomAmenityGroup) => new
                 {
                     RoomId = room.ROOM_ID,
                     RoomName = room.ROOM_NAME,
                     Amenities = roomAmenityGroup.ToList()
                 })
             .Select(grouped => new
             {
                 grouped.RoomId,
                 grouped.RoomName,
                 Amenities = grouped.Amenities.Where(ra => ra != null).ToList()
             });


            List<RoomAmenityVM> objData = new List<RoomAmenityVM>();

            foreach (var item in objRoomAmenities)
            {
                var objRoomVM = new RoomAmenityVM
                {
                    ROOM_ID = item.RoomId,
                    ROOM_NAME = item.RoomName
                };

                if (item.Amenities != null && item.Amenities.Any())
                {
                    // Extract ID and AMENITY_NAME directly in the constructor of RoomAmenityVM
                    objRoomVM.AMENITIES.AddRange(item.Amenities.Select(amenity => new AmenityOnly
                    {
                        ID = amenity.AMENITY.ID,
                        AMENITY_NAME = amenity.AMENITY.AMENITY_NAME
                    }));
                }

                objData.Add(objRoomVM);
            }

            return View("Index", objData);
        }

        public IActionResult GetRoomList()
        {
         
            var objRoomList = _IRoomService.GetAll();
            var objAmenityList = _IAmenityOnlyService.GetAll();
       

            return Json(new { data = objAmenityList });            
        }


        [HttpPost]
        public IActionResult GetSelectedRoom(int rooM_ID = 0)
        {

            var objRoomAmenity = _IRoomAmenityService.GetAll().Where(fw => fw.ROOM_ID == rooM_ID);
            var objAmenityList = _IAmenityOnlyService.GetAll();

           

            return PartialView("Common/_RoomAmenity", objAmenityList);
        }






    }
}
