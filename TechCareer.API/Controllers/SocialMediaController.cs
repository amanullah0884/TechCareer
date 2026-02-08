using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public SocialMediaController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mediaList = await _unitOfWork.JobSeekersSocialMediaRepo.GetAll();
            return Ok(mediaList);
        }

        [HttpGet("GetAllJobSeekersSocialMedia/{id}")]
        public async Task<IActionResult> GetAllJobSeekersSocialMedia(int id)
        {
            var mediaList = await _unitOfWork.JobSeekersSocialMediaRepo
                .GetAll(s => s.Id == id, null);

            return Ok(mediaList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var media = await _unitOfWork.JobSeekersSocialMediaRepo.GetById(id);

            if (media == null)
                return NotFound("Social media record not found");

            return Ok(media);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobSeekersSocialMedia entity)
        {
            if (entity == null)
                return BadRequest("JobSeekersSocialMedia object is null");

            await _unitOfWork.JobSeekersSocialMediaRepo.Add(entity);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobSeekersSocialMedia entity)
        {
            if (entity == null || id != entity.Id)
                return BadRequest("Invalid JobSeekersSocialMedia data");

            await _unitOfWork.JobSeekersSocialMediaRepo.Update(entity);
            await _unitOfWork.SaveAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var media = await _unitOfWork.JobSeekersSocialMediaRepo.GetById(id);

            if (media == null)
                return NotFound("Social media record not found");

            _unitOfWork.JobSeekersSocialMediaRepo.Delete(media);
            await _unitOfWork.SaveAsync();

            return Ok("Deleted successfully");
        }
    }
}
