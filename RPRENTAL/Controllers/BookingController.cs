using DataWrapper.Interface;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace RPRENTAL.Controllers
{
    public class BookingController : Controller
    {

        private readonly IWorker _IWorker;
        public BookingController(IWorker IWorker)
        {
            _IWorker = IWorker; 
        }
        public IActionResult Index()
        {
            return View();
        }
    

        [HttpGet]
        public IActionResult CreateBooking()
        {
            Booking objBooking = new();

            return PartialView("Create", objBooking);

        }
    }
}
