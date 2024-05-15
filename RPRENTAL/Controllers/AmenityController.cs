using DataService.Implementation;
using DataService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Model;
using RPRENTAL.ViewModels;
using Utility;
using Stripe.TestHelpers.Treasury;
using Microsoft.AspNetCore.Authorization;

namespace RPRENTAL.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IAmenityService _IAmenityService;
        private readonly IHelper _helper;
        private readonly ICompositeViewEngine _viewEngine;
        public AmenityController(IAmenityService IAmenityService, IHelper helper, ICompositeViewEngine viewEngine)
        {
            _IAmenityService = IAmenityService;
            _helper = helper;
            _viewEngine = viewEngine;
        }

        public IActionResult Index()
        {

            try
            {
                var objAmenity = _IAmenityService.GetAll();
                return View(objAmenity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Amenity> objAmenity;
            objAmenity = _IAmenityService.GetAll();
            return Json(new { data = objAmenity });
        }


        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Amenity objAmenity = new();

            PartialViewResult pvr = PartialView("Create", objAmenity);
            string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

            return Json(new { success = true, message = "", htmlContent = html_string });
             
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Amenity objAmenity)
        {

            try
            {
                Boolean isAmenityExists = _IAmenityService.IsAmenityExists(objAmenity.AmenityName);

                if (isAmenityExists)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordExists });
                }

                if (ModelState.IsValid && objAmenity.AmenityId == 0)
                {
                    _IAmenityService.Create(objAmenity);
                }

                return Json(new { success = true, message = SD.CrudTransactionsMessage.Save });

            }

            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }

        }

        [Authorize]
        [HttpGet]
        public IActionResult Update(int AmenityId)
        {
            try
            {
                Amenity objAmenity;
                objAmenity = _IAmenityService.Get(AmenityId);

                if (objAmenity == null)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound });
                }

                PartialViewResult pvr = PartialView("Update", objAmenity);
                string html_string = _helper.ViewToString(this.ControllerContext, pvr, _viewEngine);

                return Json(new { success = true, message = "", htmlContent = html_string });
            }
            catch(Exception ex)
            {
                return Json(new { success = false , message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
           
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(Amenity objAmenity)
        {
            try
            {
                if (!ModelState.IsValid && objAmenity.AmenityId <= 0)
                {
                    return Json(new {success =false, message = SD.CrudTransactionsMessage.RecordNotFound });
                }

                _IAmenityService.Update(objAmenity);                  
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Edit });
                
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + "  " + SD.SystemMessage.ContactAdmin });
            }
            
        }

        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int AmenityId)
        {
            try
            {
                if (AmenityId == 0)
                {
                    return Json(new { success = false, message = SD.CrudTransactionsMessage.RecordNotFound });
                }

                _IAmenityService.Delete(AmenityId);                  
                return Json(new { success = true, message = SD.CrudTransactionsMessage.Delete});
            

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message + " " + SD.SystemMessage.ContactAdmin });
            }
        }


       
    }
}
