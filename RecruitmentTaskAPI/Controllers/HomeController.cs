using Microsoft.AspNetCore.Mvc;

namespace RecruitmentTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        public string Home()
        {
            return string.Empty;
        }
    }
}
