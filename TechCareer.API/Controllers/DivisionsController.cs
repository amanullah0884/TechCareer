using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Location;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public DivisionsController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var divisions = await _unitofWork.DivisionRepo.GetAll();
            return Ok(divisions);
        }
        [HttpGet("GetAllCompanies/{id}")]
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var divisions = await _unitofWork.DivisionRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(divisions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var division = await _unitofWork.DivisionRepo.GetById(id);
            return Ok(division);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Division entity)
        {
            await _unitofWork.DivisionRepo.Add(entity);
            var result = _unitofWork.Save();
            return Created("GetAllCompanies", result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Put(Division entity)
        //{
        //    await _unitofWork.DivisionRepo.Update(entity);
        //    var result = _unitofWork.Save();
        //    return Ok(result);
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Division entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Division data.");

            await _unitofWork.DivisionRepo.Update(entity);
            var result = _unitofWork.Save();

            return Ok(entity);
        }

        // DELETE: api/CompanyOwnerships
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var division = await _unitofWork.DivisionRepo.GetById(id);
            if (division == null)
                return NotFound($"Country with ID {id} not found.");

            _unitofWork.DivisionRepo.Delete(division);
            _unitofWork.Save();

            return NoContent();
        }
    }
}
