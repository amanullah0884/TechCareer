using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Location;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public AreasController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var areas = await _unitofWork.AreaRepo.GetAll();
            return Ok(areas);
        }
        [HttpGet("GetAllCompanies/{id}")]
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var areas = await _unitofWork.AreaRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(areas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var area = await _unitofWork.AreaRepo.GetById(id);
            return Ok(area);
        }
        [HttpPost]
        public async Task<IActionResult> Post( TechCareer_DLL.Models.SiteSettings.Location.Area entity)
        {
            await _unitofWork.AreaRepo.Add(entity);
            var result = _unitofWork.Save();
            return Created("GetAllCompanies", result);
        }
        [HttpPut]
        public async Task<IActionResult> Put( TechCareer_DLL.Models.SiteSettings.Location.Area entity)
        {
            await _unitofWork.AreaRepo.Update(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Put( TechCareer_DLL.Models.SiteSettings.Location.Area entity)
        //{
        //    await _unitofWork.AreaRepo.Update(entity);
        //    var result = _unitofWork.Save();
        //    return Ok(result);
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Area entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Area data.");

            await _unitofWork.AreaRepo.Update(entity);
            var result = _unitofWork.Save();

            return Ok(entity);
        }

        // DELETE: api/Area
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var area = await _unitofWork.AreaRepo.GetById(id);
            if (area == null)
                return NotFound($"Area with ID {id} not found.");

            _unitofWork.AreaRepo.Delete(area);
            _unitofWork.Save();

            return NoContent();
        }

    }
}
