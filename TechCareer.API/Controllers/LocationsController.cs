using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Location;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public LocationsController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var location = await _unitofWork.LocationRepo.GetAll();
            return Ok(location);
        }
        [HttpGet("GetAllCompanies/{id}")]
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var location = await _unitofWork.LocationRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(location);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var location = await _unitofWork.LocationRepo.GetById(id);
            return Ok(location);
        }
        //[HttpPost]
        //public async Task<IActionResult> Post( TechCareer_DLL.Models.SiteSettings.Location.Location entity)
        //{
        //    await _unitofWork.LocationRepo.Add(entity);
        //    var result = _unitofWork.Save();
        //    return Created("GetAllCompanies", result);
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Location entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Location data.");

            await _unitofWork.LocationRepo.Update(entity);
            var result = _unitofWork.Save();

            return Ok(entity);
        }

        // DELETE: api/Location
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var location = await _unitofWork.LocationRepo.GetById(id);
            if (location == null)
                return NotFound($"Location with ID {id} not found.");

            _unitofWork.LocationRepo.Delete(location);
            _unitofWork.Save();

            return NoContent();
        }
    }
}
