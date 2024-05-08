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
            try
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

                return Json(new { success = true, htmlContent = html_string });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + "  " + SD.SystemMessage.ContactAdmin });
            }          

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(RoomNumberVM objRoomNumberVM)
        {
            try
            {

                bool IsRoomNumberExists = _IRoomNumberService.IsRoomNumberExists(objRoomNumberVM.RoomNumber!.RoomNo);

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
                    .ToList();
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordExists });
                }


                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput });
                }

                _IRoomNumberService.Create(objRoomNumberVM.RoomNumber);
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Save });
            
            }

            catch(Exception ex) {
            
                return Json(new {success = false, message =  ex.Message + " " + SD.SystemMessage.ContactAdmin});
            }
            
        }


        [HttpGet]
        public IActionResult Update(int RoomNo)
        {
            try
            {

                if (RoomNo == 0)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput });
                }


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

                return Json(new { success = true, htmlContent = html_string });

            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }


        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(RoomNumberVM objRoomNumberVM)
        {
            try
            {

                if (!ModelState.IsValid)
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

                    return Json(new { success = false, message = SD.CrudTransactionsMessage.InvalidInput });
                }

                _IRoomNumberService.Update(objRoomNumberVM.RoomNumber!);
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Edit });
            }
            catch(Exception ex) {

                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });                    
            }
          
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<RoomNumber> objRoomNumber;
            objRoomNumber = _IRoomNumberService.GetAll();
            return Json(new { data = objRoomNumber });

        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int RoomNo)
        {
            try
            {
                if (RoomNo != 0)
                {
                    _IRoomNumberService.Delete(RoomNo);                 
                    return Json(new { success = true, message = "Room number deleted successfully." });
                }
                return Json(new { success = false, message = "The Room number value is null or empty. Kindly contact system administrator." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}
