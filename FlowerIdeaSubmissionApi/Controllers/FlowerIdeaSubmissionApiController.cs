using Microsoft.AspNetCore.Mvc;

namespace FlowerIdeaSubmissionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlowerIdeaSubmissionApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test(string test)
        {
            return Ok(test);
        }
    }
}
