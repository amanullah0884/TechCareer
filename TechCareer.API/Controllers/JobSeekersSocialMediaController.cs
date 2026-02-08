using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekersSocialMediaController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobSeekersSocialMediaController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var socialMediaLinks = await _unitOfWork.JobSeekersSocialMediaRepo.GetAll();
            return Ok(socialMediaLinks);
        }

        [HttpGet("GetAllSocialMedia/{id}")]
        public async Task<IActionResult> GetAllSocialMedia(int id)
        {
            var list = await _unitOfWork.JobSeekersSocialMediaRepo.GetAll(s => s.Id == id, null);
            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var social = await _unitOfWork.JobSeekersSocialMediaRepo.GetById(id);

            if (social == null)
                return NotFound("Social media link not found");

            return Ok(social);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobSeekersSocialMedia entity)
        {
            if (entity == null)
                return BadRequest("Social media object is null");

            await _unitOfWork.JobSeekersSocialMediaRepo.Add(entity);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobSeekersSocialMedia entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Id or object");

            await _unitOfWork.JobSeekersSocialMediaRepo.Update(entity);
            await _unitOfWork.SaveAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var social = await _unitOfWork.JobSeekersSocialMediaRepo.GetById(id);

            if (social == null)
                return NotFound("Social media link not found");

            _unitOfWork.JobSeekersSocialMediaRepo.Delete(social);
            await _unitOfWork.SaveAsync();

            return Ok("Deleted successfully");
        }
    }
}
