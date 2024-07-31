using FlowerIdeaSubmissionApi.Mapper;
using FlowerIdeaSubmissionApi.Models;
using FlowerIdeaSubmissionApi.Repository.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowerIdeaSubmissionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowerIdeaSubmissionApiController : ControllerBase
    {
        private IIdeaRepository _ideaRepository;
        private IIdeaMapper _ideaMapper;

        public FlowerIdeaSubmissionApiController(IIdeaRepository ideaRepository, IIdeaMapper ideaMapper)
        {
            _ideaRepository = ideaRepository;
            _ideaMapper = ideaMapper;
        }
        [AllowAnonymous]
        [HttpPost("CreatedIdea")]
        public IActionResult CreatedIdea([FromBody] IdeaModel model)
        {

            if (!ModelState.IsValid)
            {
                var firstError = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).First();
                return BadRequest(firstError);
            }

            _ideaRepository.Create(_ideaMapper.CreatedIdeaDb(model));

            return Ok(new { message = "Мы обязательно вам перезвоним. Спасибо за вашу идею" });
        }
    }
}
