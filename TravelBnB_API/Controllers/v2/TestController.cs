using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelBnB_API.Controllers.v2
{
    [Route("/api/v{version:ApiVersion}/apartmentnumber")]
    [ApiController]
    [ApiVersion("2.0")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Stiamo lavorando alla versione 2 delle api");
        }
    }
}
