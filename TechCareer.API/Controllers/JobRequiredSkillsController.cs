using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerJob_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobRequiredSkillsController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobRequiredSkillsController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/JobRequiredSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobRequiredSkills>>> GetAll()
        {
            var skills = await _unitOfWork.JobRequiredSkillRepo.GetAll();
            return Ok(skills);
        }

        // GET: api/JobRequiredSkills
        [HttpGet("{id}")]
        public async Task<ActionResult<JobRequiredSkills>> GetById(int id)
        {
            var skill = await _unitOfWork.JobRequiredSkillRepo.GetById(id);
            if (skill == null)
                return NotFound();

            return Ok(skill);
        }

        // POST: api/JobRequiredSkills
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] JobRequiredSkills skill)
        {
            await _unitOfWork.JobRequiredSkillRepo.Add(skill);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = skill.Id }, skill);
        }

        // PUT: api/JobRequiredSkills
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] JobRequiredSkills skill)
        {
            if (id != skill.Id)
                return BadRequest("ID mismatch.");

            await _unitOfWork.JobRequiredSkillRepo.Update(skill);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        // DELETE: api/JobRequiredSkills
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var skill = await _unitOfWork.JobRequiredSkillRepo.GetById(id);
            if (skill == null)
                return NotFound();

            await _unitOfWork.JobRequiredSkillRepo.DeletebyID(id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
