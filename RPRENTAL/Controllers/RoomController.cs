using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace RPRENTAL.Controllers
{
    public class RoomController : Controller
    {
        private IRoomService _IRoomService;          
       

        public RoomController(IRoomService roomService)
        {
            _IRoomService = roomService;
        }


        public IActionResult Index()
        {
            try
            {
                var objRoom = _IRoomService.GetAll();
                return View(objRoom);
            }
            catch (Exception ex)
            {
                throw;
            }
               
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Room> objRoom;
            objRoom = _IRoomService.GetAll();
            
            return Json(new {data = objRoom});        
        
        }

        [HttpPost]
        public IActionResult Update(Room objRoom)
        {
            try
            {
                if (ModelState.IsValid && objRoom.ROOM_ID > 0)
                {
                    _IRoomService.Update(objRoom);
                }            
            }catch (Exception ex) { 
            
            }
           return RedirectToAction("Index");
        
        }
    }
}
