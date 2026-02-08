using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.BillingInformation;
using TechCareer_DLL.Models.SiteSettings;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public SkillsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var skill = await _unitofWork.SkillsRepo.GetAll();
            return Ok(skill);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _unitofWork.SkillsRepo.GetById(id);
            if (skill == null)
                return NotFound("Skills not found");
            return Ok(skill);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Skill skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.SkillsRepo.Add(skill);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Skill skill)
        {
            var existing = await _unitofWork.SkillsRepo.GetById(skill.Id);
            if (existing == null)
                return NotFound("Skill Not found");
            await _unitofWork.SkillsRepo.Update(skill);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.SkillsRepo.GetById(id);
            if (entity == null)
                return NotFound("Skill Not found");
            _unitofWork.SkillsRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
