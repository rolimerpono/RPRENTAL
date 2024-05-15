using DataService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Model;
using Utility;

namespace RPRENTAL.Controllers
{
  
    public class RoomController : Controller
    {
        private readonly IRoomService _IRoomService;
        private readonly IHelper _helper;
        private readonly ICompositeViewEngine _viewEngine;

        public RoomController(IRoomService roomService, IHelper helper, ICompositeViewEngine viewEngine)
        {
            _IRoomService = roomService;
            _helper = helper;
            _viewEngine = viewEngine;
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

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Room objRoom;
            try
            {
                objRoom = new Room { RoomId = 0, Description = "", RoomName = "", RoomPrice = 0, MaxOccupancy = 0, ImageUrl = "https://placehold.co/600x400", CreatedDate = DateTime.Now };

                
                PartialViewResult pvr = PartialView("Create", objRoom);
                string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

                return Json(new { success = true, htmlContent = html_string });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }

        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Room objRoom)
        {
            try
            {

                bool is_exists = _IRoomService.IsRoomNameExists(objRoom);

                if (is_exists)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordExists });
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput});
                }

                _IRoomService.Create(objRoom);                 
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Save });              

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message  + " " + SD.SystemMessage.ContactAdmin});
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int RoomId)
        {
            try
            {
                Room objRoom;

                objRoom = _IRoomService.Get(RoomId);

                if (objRoom == null)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput });            
                }
                
                PartialViewResult pvr = PartialView("Update", objRoom);
                string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);
                return Json(new { success = true, message = "", htmlContent = html_string });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
        
        }


        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(Room objRoom, IFormFile Image)
        {
            try
            {
                if(objRoom.Image == null)
                {
                    ModelState.Remove("Image");
                }

                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput });

                }
                _IRoomService.Update(objRoom);                   
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Edit });
             
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
            
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int RoomId)
        {
            try
            {
                if (RoomId <= 0)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound });
                }

                _IRoomService.Delete(RoomId);                
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Delete });           

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
        }
    }
}
