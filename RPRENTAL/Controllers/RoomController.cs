using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Model;

namespace RPRENTAL.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _IRoomService;         

        public RoomController(IRoomService roomService)
        {
            _IRoomService = roomService;
        }

        public IActionResult Notification()
        {
            return PartialView("_Notification",TempData);
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
        public IActionResult Create()
        {
            Room objRoom;
            try
            {
                objRoom = new Room { ROOM_ID = 0, DESCRIPTION = "", ROOM_NAME = "", ROOM_PRICE = 0, MAX_OCCUPANCY = 0, IMAGE_URL = "https://placehold.co/600x400", CREATED_DATE = DateTime.Now };

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return PartialView("Create", objRoom);

        }

        [HttpPost]
        public IActionResult Create(Room objRoom)
        {
            try
            {
                if (ModelState.IsValid && objRoom.ROOM_ID == 0)
                {
                    _IRoomService.Create(objRoom);
                    TempData["success"] = "Room created successfully.";
                    return Json(new { success = true, message = "Room created successfully." });
                }
                return Json(new { success = false, message = "Something went wrong." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

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

                    TempData["success"] = "Room updated successfully.";
                    return Json(new { success = true, message = "Room updated successfully."  });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return RedirectToAction("Index");        
        }

        [HttpPost]
        public IActionResult Delete(int ROOM_ID)
        {
            try
            {
                if (ROOM_ID != 0)
                {

                    _IRoomService.Delete(ROOM_ID);
                    TempData["success"] = "Room deleted successfully.";
                    return Json(new { success = true, message = "Room deleted successfully." });
                }
                return Json(new { success = false, message = "Something went wrong." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
