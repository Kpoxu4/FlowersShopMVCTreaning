using FlowerIdeaSubmissionApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowerIdeaSubmissionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowerIdeaSubmissionApiController : ControllerBase
    {
        [HttpPost("CreatedIdea")]
        public IActionResult CreatedIdea(IdeaModel idea)
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(ModelState);
            }
            // Логика сохранения идеи
            return Ok(new { message = "Идея успешно создана!" });
        }
    }
}
