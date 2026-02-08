using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings;
using TechCareer_DLL.Models.SiteSettings.Education;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelOfEducationsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public LevelOfEducationsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lavelOfEdu = await _unitofWork.LevelOfEducationRepo.GetAll();
            return Ok(lavelOfEdu);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var lavelOfEdu = await _unitofWork.LevelOfEducationRepo.GetById(id);
            if (lavelOfEdu == null)
                return NotFound("levelOfEducations not found");
            return Ok(lavelOfEdu);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LevelOfEducation levelOfEducations)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.LevelOfEducationRepo.Add(levelOfEducations);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] LevelOfEducation levelOfEducations)
        {
            var existing = await _unitofWork.LevelOfEducationRepo.GetById(levelOfEducations.Id);
            if (existing == null)
                return NotFound("levelOfEducations Not found");
            await _unitofWork.LevelOfEducationRepo.Update(levelOfEducations);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.LevelOfEducationRepo.GetById(id);
            if (entity == null)
                return NotFound("levelOfEducations Not found");
            _unitofWork.LevelOfEducationRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}

