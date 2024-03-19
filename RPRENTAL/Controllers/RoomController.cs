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

        [HttpGet]
        public IActionResult Update(int ROOM_ID)
        {
            try
            {
                Room objRoom;
                objRoom = _IRoomService.Get(ROOM_ID);
                return PartialView("Update", objRoom);
            }
            catch (Exception ex)
            {
                throw;
            }
        
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

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                Room objRoom =new Room{ ROOM_ID = 0, DESCRIPTION="", ROOM_NAME ="", ROOM_PRICE = 0, MAX_OCCUPANCY = 0, IMAGE_URL = "https://placehold.co/600x400", CREATED_DATE = DateTime.Now };             
                return PartialView("Create", objRoom);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        public IActionResult Create(Room objRoom)
        {
            try
            {
                if (ModelState.IsValid && objRoom.ROOM_ID == 0)
                {
                    _IRoomService.Create(objRoom);                   
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
