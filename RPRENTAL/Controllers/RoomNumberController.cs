using DataService.Implementation;
using DataService.Interface;
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
                
                RoomList = _IRoomService.GetAll().Select(fw => new SelectListItem
                {
                    Text = fw.RoomName,
                    Value = fw.RoomId.ToString()
                   
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
            Boolean IsRoomNumberExists = _IRoomNumberService.IsRoomNumberExists(objRoomNumberVM.RoomNumber!.RoomNo);


            if (IsRoomNumberExists)
            {             

                objRoomNumberVM.RoomList = new List<SelectListItem>();

                objRoomNumberVM.RoomList = _IRoomService.GetAll().Select(fw => new SelectListItem
                {
                    Text = fw.RoomName,
                    Value = fw.RoomId.ToString() 
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
                _IRoomNumberService.Create(objRoomNumberVM.RoomNumber);
                return Json(new { success = true, message = "Room number created successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Something went wrong..." });
            }         
        }


        [HttpGet]
        public IActionResult Update(int RoomNo)
        {

            RoomNumberVM objRoomNumberVM = new RoomNumberVM()            {

                RoomList = _IRoomService.GetAll().Select(fw => new SelectListItem
                {
                    Text = fw.RoomName,
                    Value = fw.RoomId.ToString()

                })
                .OrderBy(fw => fw.Text)
                 .GroupBy(fw => fw.Text)
                 .Select(fw => fw.First()),
                
                RoomNumber = _IRoomNumberService.Get(RoomNo)
            };
            

            return PartialView("Update", objRoomNumberVM);

        }

        [HttpPost]
        public IActionResult Update(RoomNumberVM objRoomNumberVM)
        {          

            if (ModelState.IsValid)
            {
                _IRoomNumberService.Update(objRoomNumberVM.RoomNumber!);
                return Json(new { success = true, message = "Room number updated successfully." });
            }
            else
            {
                objRoomNumberVM.RoomList = new List<SelectListItem>();

                objRoomNumberVM.RoomList = _IRoomService.GetAll().Select(fw => new SelectListItem
                {
                    Text = fw.RoomName,
                    Value = fw.RoomId.ToString()
                })
                .OrderBy(fw => fw.Text)
                .GroupBy(fw => fw.Text)
                .Select(fw => fw.First())
                .ToList()
                ;

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
        public IActionResult Delete(int RoomNo)
        {
            try
            {
                if (RoomNo != 0)
                {
                    _IRoomNumberService.Delete(RoomNo);                 
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
