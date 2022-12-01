using Microsoft.AspNetCore.Mvc;

namespace OneToManyAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class EnginesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
