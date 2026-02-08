using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerSkillController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobSeekerSkillController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _unitOfWork.JobSeekerSkillRepo.GetAll();
            return Ok(skills);
        }

        [HttpGet("GetAllSkills/{id}")]
        public async Task<IActionResult> GetAllSkills(int id)
        {
            var list = await _unitOfWork.JobSeekerSkillRepo
                        .GetAll(s => s.Id == id, null);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _unitOfWork.JobSeekerSkillRepo.GetById(id);

            if (skill == null)
                return NotFound("Skill not found");

            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobSeekerSkill entity)
        {
            if (entity == null)
                return BadRequest("Skill object is null");

            await _unitOfWork.JobSeekerSkillRepo.Add(entity);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobSeekerSkill entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Id or object");

            await _unitOfWork.JobSeekerSkillRepo.Update(entity);
            await _unitOfWork.SaveAsync();

            return Ok(entity);
        }

  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _unitOfWork.JobSeekerSkillRepo.GetById(id);

            if (skill == null)
                return NotFound("Skill not found");

            _unitOfWork.JobSeekerSkillRepo.Delete(skill);
            await _unitOfWork.SaveAsync();

            return Ok("Deleted successfully");
        }
    }
}
