using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Education;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public InstitutionsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lavelOfEdu = await _unitofWork.InstitutionRepo.GetAll();
            return Ok(lavelOfEdu);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var institution = await _unitofWork.InstitutionRepo.GetById(id);
            if (institution == null)
                return NotFound("Institution not found");
            return Ok(institution);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Institution institution) { 
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.InstitutionRepo.Add(institution);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Institution institution)
        {
            var existing = await _unitofWork.InstitutionRepo.GetById(institution.Id);
            if (existing == null)
                return NotFound("Institution Not found");
            await _unitofWork.InstitutionRepo.Update(institution);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.InstitutionRepo.GetById(id);
            if (entity == null)
                return NotFound("Institution Not found");
            _unitofWork.InstitutionRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}

