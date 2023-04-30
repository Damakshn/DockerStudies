using Microsoft.AspNetCore.Mvc;

namespace BookingPro.API.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content($"Index goes here ({_configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") ?? "undefined"}) mode");
        }
    }
}
