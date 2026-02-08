using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Education;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeOrExamsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public DegreeOrExamsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var degree = await _unitofWork.DegreeOrExamRepo.GetAll();
            return Ok(degree);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var degree = await _unitofWork.DegreeOrExamRepo.GetById(id);
            if (degree == null)
                return NotFound("levelOfEducations not found");
            return Ok(degree);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DegreeOrExam degreeOrExam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.DegreeOrExamRepo.Add(degreeOrExam);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DegreeOrExam degreeOrExam)
        {
            var existing = await _unitofWork.DegreeOrExamRepo.GetById(degreeOrExam.Id);
            if (existing == null)
                return NotFound("DegreeOrExamRepo Not found");
            await _unitofWork.DegreeOrExamRepo.Update(degreeOrExam);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.DegreeOrExamRepo.GetById(id);
            if (entity == null)
                return NotFound("DegreeOrExamRepo Not found");
            _unitofWork.DegreeOrExamRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}

