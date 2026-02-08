using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobSeekerController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/JobSobSeekerkerExperiences  
        [HttpGet]
        public async Task<IActionResult> GetAllJobSeekerExperience()
        {
            var jobSeekerExperiences = await _unitOfWork.JobSeekerExperienceRepo.GetAll();
            return Ok(jobSeekerExperiences);
        }

        // GET: api/JobSobSeekerkerExperiences  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobSeekerExperienceID(int id)
        {
            var jobSeekerExperiences = await _unitOfWork.JobSeekerExperienceRepo.GetById(id);
            if (jobSeekerExperiences == null)
                return NotFound();
            return Ok(jobSeekerExperiences);
        }

        // POST: api/JobSobSeekerkerExperiences  
        [HttpPost]
        public async Task<IActionResult> CreateJobExperience([FromBody] JobSeekerExperience jobSeekerExperience)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _unitOfWork.JobSeekerExperienceRepo.Add(jobSeekerExperience);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetJobSeekerExperienceID), new { id = jobSeekerExperience.Id }, jobSeekerExperience);
        }

        // PUT: api/JobSobSeekerkerExperiences  
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobExperience(int id, [FromBody] JobSeekerExperience jobSeekerExperience)
        {
            var existing = await _unitOfWork.JobSeekerExperienceRepo.GetById(id);
            if (existing == null)
                return NotFound();

            // Update properties of the existing object with the new values  
            existing.CompanyName = jobSeekerExperience.CompanyName;
            existing.Designation = jobSeekerExperience.Designation;
            existing.StartDate = jobSeekerExperience.StartDate;
            existing.EndDate = jobSeekerExperience.EndDate;
            existing.IsContinue = jobSeekerExperience.IsContinue;
            existing.Responsibilities = jobSeekerExperience.Responsibilities;
            existing.AreaOfExpertise = jobSeekerExperience.AreaOfExpertise;

            await _unitOfWork.JobSeekerExperienceRepo.Update(existing);
            await _unitOfWork.SaveAsync();

            return Ok(existing);
        }

        // DELETE: api/JobSobSeekerkerExperiences  
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobSeekerExperience(int id)
        {
            var jobSeekerExperience = await _unitOfWork.JobSeekerExperienceRepo.GetById(id);
            if (jobSeekerExperience == null)
                return NotFound();

            _unitOfWork.JobSeekerExperienceRepo.Delete(jobSeekerExperience);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
