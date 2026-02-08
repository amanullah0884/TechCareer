using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerJob_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobPostController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/JobPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPost>>> GetAllJobPosts()
        {
            var jobs = await _unitOfWork.JobPostRepo.GetAll();
            return Ok(jobs);
        }

        // GET: api/JobPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPost>> GetJobPostById(int id)
        {
            var job = await _unitOfWork.JobPostRepo.GetById(id);
            if (job == null)
                return NotFound();

            return Ok(job);
        }

        // POST: api/JobPost
        [HttpPost]
        public async Task<ActionResult> CreateJobPost([FromBody] JobPost jobPost)
        {
            await _unitOfWork.JobPostRepo.Add(jobPost);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetJobPostById), new { id = jobPost.Id }, jobPost);
        }

        // PUT: api/JobPost
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJobPost(int id, [FromBody] JobPost jobPost)
        {
            if (id != jobPost.Id)
                return BadRequest("Job ID mismatch.");

            await _unitOfWork.JobPostRepo.Update(jobPost);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        // DELETE: api/JobPost
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJobPost(int id)
        {
            var job = await _unitOfWork.JobPostRepo.GetById(id);
            if (job == null)
                return NotFound();

            await _unitOfWork.JobPostRepo.DeletebyID(id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
