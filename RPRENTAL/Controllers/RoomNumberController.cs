using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Model;
using RPRENTAL.ViewModels;
using StaticUtility;
using System.Runtime.CompilerServices;

namespace RPRENTAL.Controllers
{
    public class RoomNumberController : Controller
    {
        private readonly IRoomNumberService _IRoomNumberService;
        private readonly IRoomService _IRoomService;
        private readonly IHelper _helper;
        private readonly ICompositeViewEngine _viewEngine;
        public RoomNumberController(IRoomNumberService IRoomNumberService, IRoomService iRoomService, IHelper helper, ICompositeViewEngine viewEngine)
        {
            _IRoomNumberService = IRoomNumberService;
            _IRoomService = iRoomService;
            _helper = helper;
            _viewEngine = viewEngine;
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

          

            PartialViewResult pvr = PartialView("Create", objRoomNumberVM);
            string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

            return Json(new { success = true, message = "", htmlContent = html_string });

        }

        [HttpPost, ValidateAntiForgeryToken]
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

            RoomNumberVM objRoomNumberVM = new RoomNumberVM()
            {

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

           
            PartialViewResult pvr = PartialView("Update", objRoomNumberVM);
            string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

            return Json(new { success = true, message = "", htmlContent = html_string });

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(RoomNumberVM objRoomNumberVM)
        {
            try
            {

                if (!ModelState.IsValid && objRoomNumberVM.RoomNumber == null)
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
                    .ToList();

                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound});
                }               
            

                _IRoomNumberService.Update(objRoomNumberVM.RoomNumber!);
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Edit });

            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<RoomNumber> objRoomNumber;
                objRoomNumber = _IRoomNumberService.GetAll();
                return Json(new { success = true, message = "", data = objRoomNumber });
            }
            catch (Exception ex)
            { 
                return Json(new {success =false , message = ex.Message + " "  + SD.SystemMessage.ContactAdmin});
            }
          

        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int RoomNo)
        {
            try
            {
                if (RoomNo != 0)
                {
                    _IRoomNumberService.Delete(RoomNo);
                    return Json(new { success = true, message = SD.CrudTransactionsMessage.Delete });
                }

                return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
        }


    }
}
