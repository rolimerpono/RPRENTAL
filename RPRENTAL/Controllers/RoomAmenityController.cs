using DataService.Interface;
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
        private readonly IAmenityService _IAmenityService;
        private readonly IRoomAmenityService _IRoomAmenityService;

        public RoomAmenityController(IRoomService iRoom, IAmenityService iAmenity, IRoomAmenityService iRoomAmenity)
        {
            _IRoomAmenityService =  iRoomAmenity;
            _IAmenityService = iAmenity;
            _IRoomService = iRoom;
        }
        public IActionResult Index()
        {

            var objRoomList = _IRoomService.GetAll();
            var objAmenityList = _IAmenityService.GetAll();
            var objRoomAmenities = _IRoomAmenityService.GetAll();

            RoomAmenityVM objData = new RoomAmenityVM();

            objData.RoomList = objRoomList.ToList();
            objData.Amenities = objAmenityList.ToList();
            objData.RoomAmenity = objRoomAmenities.ToList();           
            

            return View("Index", objData);
        }

    


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult DisplayRoomAmenities(int Id)
        {           

            var objRoomList = _IRoomService.GetAll();

            var objRoomAmenities = _IRoomService.GetAll()
                .Where(room => room.RoomId == Id) 
                .GroupJoin(
                    _IRoomAmenityService.GetAll(),
                    room => room.RoomId,
                    roomAmenity => roomAmenity.RoomId,
                    (room, roomAmenityGroup) => new
                    {
                        RoomId = room.RoomId,
                        RoomName = room.RoomName,
                        Amenities = roomAmenityGroup.ToList()
                    })
                .Select(grouped => new
                {
                    grouped.RoomId,
                    grouped.RoomName,
                    RoomAmenities = _IAmenityService.GetAll()
                        .Select(amenity =>
                        {
                            var roomAmenity = grouped.Amenities.FirstOrDefault(ra => ra.AmenityId == amenity.AmenityId);
                            return new
                            {
                                Amenity = amenity,
                                IsCheck = roomAmenity != null ? true : false
                            };
                        })
                        .ToList()
                })
                .FirstOrDefault(); 

            RoomAmenityVM objData = new RoomAmenityVM();
            objData.RoomAmenity = new List<RoomAmenity>();
            objData.RoomList = new List<Room>();
            objData.RoomId = objRoomAmenities!.RoomId;
            objData.RoomName = objRoomAmenities.RoomName;
          
           
            foreach (var oAmenity in objRoomAmenities.RoomAmenities.ToList())
            {
               
                var newAmenity = new Amenity
                {

                    AmenityId = oAmenity.Amenity.AmenityId,
                    AmenityName = oAmenity.Amenity.AmenityName,
                    IsCheck = oAmenity.IsCheck,
                   
                };
              
                objData.Amenities.Add(newAmenity);
            }

            return PartialView("Common/_RoomAmenity",objData);
        }

        [HttpGet]
        public IActionResult GetRoomList()
        {
            var objRoomList = _IRoomService.GetAll();

            return Json(new { data = objRoomList });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ApplyRoomAmenities(int Id, string jsonData)
        {
            try
            {
                if(Id != 0) {
                    _IRoomAmenityService.Delete(Id);
                }

                var objAmenityList = JsonConvert.DeserializeObject<List<Amenity>>(jsonData);


                if (objAmenityList != null)
                {


                    foreach (var item in objAmenityList)
                    {

                        var objAmenity = new RoomAmenity { Id = 0, RoomId = Id, AmenityId = item.AmenityId };
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
