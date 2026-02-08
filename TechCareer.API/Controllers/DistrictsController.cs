using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Location;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public DistrictsController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var districts = await _unitofWork.DistrictRepo.GetAll();
            return Ok(districts);
        }
        [HttpGet("GetAllCompanies/{id}")]
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var districts = await _unitofWork.DistrictRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(districts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var district = await _unitofWork.DistrictRepo.GetById(id);
            return Ok(district);
        }
        [HttpPost]
        public async Task<IActionResult> Post(District entity)
        {
            await _unitofWork.DistrictRepo.Add(entity);
            var result = _unitofWork.Save();
            return Created("GetAllCompanies", result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Put(District entity)
        //{
        //    await _unitofWork.DistrictRepo.Update(entity);
        //    var result = _unitofWork.Save();
        //    return Ok(result);
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] District entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid District data.");

            await _unitofWork.DistrictRepo.Update(entity);
            var result = _unitofWork.Save();

            return Ok(entity);
        }

        // DELETE: api/CompanyOwnerships
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var district = await _unitofWork.DistrictRepo.GetById(id);
            if (district == null)
                return NotFound($"District with ID {id} not found.");

            _unitofWork.DistrictRepo.Delete(district);
            _unitofWork.Save();

            return NoContent();
        }
    }
}
