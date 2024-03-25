using Microsoft.AspNetCore.Mvc;

namespace RPRENTAL.Controllers
{
    public class AmenityOnlyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public AmenityOnlyController()
        {
            
        }
    }
}
