using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public ResumeController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resumes = await _unitOfWork.ResumeRepo.GetAll();
            return Ok(resumes);
        }


        [HttpGet("GetAllResume/{id}")]
        public async Task<IActionResult> GetAllResume(int id)
        {
            var resumes = await _unitOfWork.ResumeRepo.GetAll(r => r.Id == id, null);
            return Ok(resumes);
        }

 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resume = await _unitOfWork.ResumeRepo.GetById(id);

            if (resume == null)
                return NotFound("Resume not found");

            return Ok(resume);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Resume entity)
        {
            if (entity == null)
                return BadRequest("Resume object is null");

            await _unitOfWork.ResumeRepo.Add(entity);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Resume entity)
        {
            if (entity == null || id != entity.Id)
                return BadRequest("Invalid resume object");

            await _unitOfWork.ResumeRepo.Update(entity);
            await _unitOfWork.SaveAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resume = await _unitOfWork.ResumeRepo.GetById(id);

            if (resume == null)
                return NotFound("Resume not found");

            _unitOfWork.ResumeRepo.Delete(resume);
            await _unitOfWork.SaveAsync();

            return Ok("Resume deleted successfully");
        }
    }
}
