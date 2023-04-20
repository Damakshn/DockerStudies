using Microsoft.AspNetCore.Mvc;

namespace BookingPro.API.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Index goes here");
        }
    }
}
