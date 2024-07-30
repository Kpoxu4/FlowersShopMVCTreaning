using FlowerIdeaSubmissionApi.Mapper;
using FlowerIdeaSubmissionApi.Models;
using FlowerIdeaSubmissionApi.Repository.Repository.Interface;
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

        [HttpPost("CreatedIdea")]
        public IActionResult CreatedIdea(IdeaModel idea)
        {
            if (!ModelState.IsValid)
            {                
                return BadRequest(ModelState);
            }

            _ideaRepository.Create(_ideaMapper.CreatedIdeaDb(idea));

            return Ok(new { message = "Мы обязательно вам перезвоним. Спасибо за вашу идею" });
        }
    }
}
