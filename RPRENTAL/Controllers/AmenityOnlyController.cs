using DataWrapper.Implementation;
using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using RPRENTAL.ViewModels;
using Stripe.TestHelpers.Treasury;

namespace RPRENTAL.Controllers
{
    public class AmenityOnlyController : Controller
    {
        private readonly IAmenityOnlyService _IAmenityOnlyService;
        public AmenityOnlyController(IAmenityOnlyService IAmenityService)
        {
            _IAmenityOnlyService = IAmenityService;
        }

        public IActionResult Index()
        {


            try
            {
                var objAmenityOnly = _IAmenityOnlyService.GetAll();
                return View(objAmenityOnly);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<AmenityOnly> objAmenityOnly;
            objAmenityOnly = _IAmenityOnlyService.GetAll();
            return Json(new { data = objAmenityOnly });
        }

        [HttpGet]
        public IActionResult Create()
        {
            AmenityOnly objAmenityOnlyVM = new();

           return PartialView("Create", objAmenityOnlyVM);
             
        }

        [HttpPost]
        public IActionResult Create(AmenityOnly objAmenityOnly)
        {
            

            Boolean isAmenityExists = _IAmenityOnlyService.IsAmenityExists(objAmenityOnly.AMENITY_NAME);

            if (isAmenityExists)
            {
                return Json(new { success = false, message = "Record already exists." });
            }


            try
            {
                if (ModelState.IsValid && objAmenityOnly.ID == 0)
                {
                    _IAmenityOnlyService.Create(objAmenityOnly);
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
        public IActionResult Update(int id)
        {
            AmenityOnly objAmenityOnly;
            objAmenityOnly = _IAmenityOnlyService.Get(id);
            if (objAmenityOnly == null)
            {
                return Json(new { sucess = false, message = "Something went wrong." });
            }
            return PartialView("Update", objAmenityOnly);
        }

        [HttpPost]
        public IActionResult Update(AmenityOnly objAmenityOnly)
        {
            try
            {
                if (ModelState.IsValid && objAmenityOnly.ID > 0)
                {
                    _IAmenityOnlyService.Update(objAmenityOnly);

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
                    _IAmenityOnlyService.Delete(id);
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
