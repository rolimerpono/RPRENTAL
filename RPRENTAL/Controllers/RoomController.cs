using DataService.Interface;
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
                objRoom = new Room { RoomId = 0, Description = "", RoomName = "", RoomPrice = 0, MaxOccupancy = 0, ImageUrl = "https://placehold.co/600x400", CreatedDate = DateTime.Now };

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

                bool is_exists = _IRoomService.IsRoomNameExists(objRoom);

                if (is_exists)
                {
                    return Json(new { success = false, message = "Room name already exists." });
                }

                if (ModelState.IsValid && objRoom.RoomId == 0)
                {
                    _IRoomService.Create(objRoom);                 
                    return Json(new { success = true, message = "Room created successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Something went wrong." });
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult Update(int RoomId)
        {
            try
            {
                Room objRoom;
                objRoom = _IRoomService.Get(RoomId);
                return PartialView("Update", objRoom);
            }
            catch (Exception ex)
            {
                throw;
            }
        
        }




        [HttpPost]
        public IActionResult Update(Room objRoom, IFormFile Image)
        {
            try
            {
                if(objRoom.Image == null)
                {
                    ModelState.Remove("Image");
                }
               
                if (ModelState.IsValid && objRoom.RoomId > 0)
                {
                    _IRoomService.Update(objRoom);

                    TempData["success"] = "Room updated successfully.";
                    return Json(new { success = true, message = "Room updated successfully." });
                }
                else
                {
                    return Json(new { success = true, message = "Something went wrong" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            
        }


        [HttpPost]
        public IActionResult Delete(int RoomId)
        {
            try
            {
                if (RoomId != 0)
                {

                    _IRoomService.Delete(RoomId);
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
