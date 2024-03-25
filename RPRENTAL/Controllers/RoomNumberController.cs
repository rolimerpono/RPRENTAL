using DataWrapper.Implementation;
using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using RPRENTAL.ViewModels;
using System.Runtime.CompilerServices;

namespace RPRENTAL.Controllers
{
    public class RoomNumberController : Controller
    {
        private readonly IRoomNumberService _IRoomNumberService;
        private readonly IRoomService _IRoomService;
        public RoomNumberController(IRoomNumberService IRoomNumberService, IRoomService iRoomService)
        {
            _IRoomNumberService = IRoomNumberService;
            _IRoomService = iRoomService;
        }
        public IActionResult Index()
        {
            try
            {
                var objRoomNumber = _IRoomNumberService.GetAll();
                return View(objRoomNumber);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult Create()
        {

            RoomNumberVM objRoomNumberVM = new RoomNumberVM()
            {
                
                ROOM_LIST = _IRoomService.GetAll().Select(fw => new SelectListItem
                {
                    Text = fw.ROOM_NAME,
                    Value = fw.ROOM_ID.ToString()
                   
                })
                .OrderBy(fw => fw.Text)
                 .GroupBy(fw => fw.Text)
                 .Select(fw => fw.First()).ToList()               
           
            };

            return PartialView("Create",objRoomNumberVM);

        }

        [HttpPost]
        public IActionResult Create(RoomNumberVM objRoomNumberVM)
        {
            Boolean IsRoomNumberExists = _IRoomNumberService.IsRoomNumberExists(objRoomNumberVM.tbl_RoomNumber.ROOM_NUMBER);


            if (IsRoomNumberExists)
            {             

                objRoomNumberVM.ROOM_LIST = new List<SelectListItem>();

                objRoomNumberVM.ROOM_LIST = _IRoomService.GetAll().Select(fw => new SelectListItem
                {
                    Text = fw.ROOM_NAME,
                    Value = fw.ROOM_ID.ToString() 
                })
                .OrderBy(fw => fw.Text)
                .GroupBy(fw => fw.Text)
                .Select(fw => fw.First())
                .ToList()
                ;
                return Json(new { success = false, message = "Warning!, Room number already exists." });
            }


            if (ModelState.IsValid && !IsRoomNumberExists)
            {
                _IRoomNumberService.Create(objRoomNumberVM.tbl_RoomNumber);
                return Json(new { success = true, message = "Room number created successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong..." });
            }         
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<RoomNumber> objRoomNumber;
            objRoomNumber = _IRoomNumberService.GetAll();

            return Json(new { data = objRoomNumber });

        }


        [HttpPost]
        public IActionResult Delete(int ROOM_NUMBER)
        {
            try
            {
                if (ROOM_NUMBER != 0)
                {
                    _IRoomNumberService.Delete(ROOM_NUMBER);
                    TempData["success"] = "Room deleted successfully.";
                    return Json(new { success = true, message = "Room number deleted successfully." });
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
