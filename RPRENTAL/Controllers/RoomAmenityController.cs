using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Model;
using Newtonsoft.Json;
using PayPal.Api;
using Repository.Interface;
using RPRENTAL.ViewModels;
using Stripe.Tax;
using System.Diagnostics;

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

            var objRoomList = _IRoomService.GetAll();
            var objAmenityList = _IAmenityOnlyService.GetAll();
            var objRoomAmenities = _IRoomAmenityService.GetAll();

            RoomAmenityVM objData = new RoomAmenityVM();

            objData.ROOM_LIST = objRoomList.ToList();
            objData.AMENITIES = objAmenityList.ToList();
            objData.ROOM_AMENITY = objRoomAmenities.ToList();           
            

            return View("Index", objData);
        }

    


        [HttpPost]
        public IActionResult DisplayRoomAmenities(int ID)
        {           

            var objRoomList = _IRoomService.GetAll();

            var objRoomAmenities = _IRoomService.GetAll()
                .Where(room => room.ROOM_ID == ID) // Filter based on the desired Room ID
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
                    RoomAmenities = _IAmenityOnlyService.GetAll()
                        .Select(amenity =>
                        {
                            var roomAmenity = grouped.Amenities.FirstOrDefault(ra => ra.AMENITY_ID == amenity.ID);
                            return new
                            {
                                Amenity = amenity,
                                IS_CHECK = roomAmenity != null ? true : false
                            };
                        })
                        .ToList()
                })
                .FirstOrDefault(); 

            RoomAmenityVM objData = new RoomAmenityVM();
            objData.ROOM_AMENITY = new List<RoomAmenity>();
            objData.ROOM_LIST = new List<Room>();
            objData.ROOM_ID = (int)ID;
          
           
            foreach (var oAmenity in objRoomAmenities.RoomAmenities.ToList())
            {
               
                var newAmenity = new AmenityOnly
                {

                    ID = oAmenity.Amenity.ID,
                    AMENITY_NAME = oAmenity.Amenity.AMENITY_NAME,
                    IS_CHECK = oAmenity.IS_CHECK,
                   
                };
              
                objData.AMENITIES.Add(newAmenity);
            }

            return PartialView("Common/_RoomAmenity",objData);
        }

        [HttpGet]
        public IActionResult GetRoomList()
        {
            var objRoomList = _IRoomService.GetAll();

            return Json(new { data = objRoomList });
        }

        [HttpPost]
        public IActionResult ApplyRoomAmenities(int ID, string jsonData)
        {
            try
            {

                var objAmenityList = JsonConvert.DeserializeObject<List<AmenityOnly>>(jsonData);

                if (objAmenityList != null)
                {
                    _IRoomAmenityService.Delete(ID);

                    foreach (var item in objAmenityList)
                    {

                        var objAmenity = new RoomAmenity { ID = 0, ROOM_ID = ID, AMENITY_ID = item.ID };
                        _IRoomAmenityService.Create(objAmenity);

                    }                   
                }
                return Json(new { success = true, message = "Room Amenities successfully applied." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Something went wrong." });
            }
        
        }

    }
}
