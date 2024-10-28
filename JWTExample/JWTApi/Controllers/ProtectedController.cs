using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetValues()
        {
            return Ok(new string[] { "value1", "value2" });
        }
    }
}
