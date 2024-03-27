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
            var objRoomList = _IRoomService.GetAll();
            var objAmenityList = _IAmenityOnlyService.GetAll();
            var objRoomAmenityList = _IRoomAmenityService.GetAll();

            RoomAmenityVM objData = new RoomAmenityVM
            {
                ROOM_LIST = objRoomList,
                AMENITY_LIST = objAmenityList,               
            };

          
           

            return View("Index");
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
