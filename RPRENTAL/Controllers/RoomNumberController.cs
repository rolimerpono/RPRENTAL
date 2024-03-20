using Microsoft.AspNetCore.Mvc;

namespace RPRENTAL.Controllers
{
    public class RoomNumberController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}
