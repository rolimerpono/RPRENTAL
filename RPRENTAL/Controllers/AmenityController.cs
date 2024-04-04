using DataWrapper.Implementation;
using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using RPRENTAL.ViewModels;
using Stripe.TestHelpers.Treasury;

namespace RPRENTAL.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IAmenityService _IAmenityService;
        public AmenityController(IAmenityService IAmenityService)
        {
            _IAmenityService = IAmenityService;
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

        [HttpGet]
        public IActionResult Create()
        {
            Amenity objAmenityVM = new();

           return PartialView("Create", objAmenityVM);
             
        }

        [HttpPost]
        public IActionResult Create(Amenity objAmenity)
        {
            

            Boolean isAmenityExists = _IAmenityService.IsAmenityExists(objAmenity.AMENITY_NAME);

            if (isAmenityExists)
            {
                return Json(new { success = false, message = "Record already exists." });
            }


            try
            {
                if (ModelState.IsValid && objAmenity.AMENITY_ID == 0)
                {
                    _IAmenityService.Create(objAmenity);
                    TempData["success"] = "Amenity created successfully.";
                    return Json(new { success = true, message = "Amenity created successfully." });
                }
                return Json(new { success = false, message = "Something went wrong." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public IActionResult Update(int amenitY_ID)
        {
            Amenity objAmenity;
            objAmenity = _IAmenityService.Get(amenitY_ID);
            if (objAmenity != null)
            {
                return PartialView("Update", objAmenity);
            }          
            return Json(new { sucess = false, message = "Something went wrong." });
        }

        [HttpPost]
        public IActionResult Update(Amenity objAmenity)
        {
            try
            {
                if (ModelState.IsValid && objAmenity.AMENITY_ID > 0)
                {
                    _IAmenityService.Update(objAmenity);

                    TempData["success"] = "Amenity updated successfully.";
                    return Json(new { success = true, message = "Amenity updated successfully." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    _IAmenityService.Delete(id);
                    TempData["success"] = "Amenity deleted successfully.";
                    return Json(new { success = true, message = "Amenity deleted successfully." });
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


       
    }
}
