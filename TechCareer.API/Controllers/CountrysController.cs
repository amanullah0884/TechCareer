using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.Location;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public CountrysController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }
        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            var countries = await _unitofWork.CountryRepo.GetAll();
            return Ok(countries);
        }
        [HttpGet("GetAllCompanies/{id}")]
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var countries = await _unitofWork.CountryRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(countries);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _unitofWork.CountryRepo.GetById(id);
            return Ok(country);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Country entity)
        {
            await _unitofWork.CountryRepo.Add(entity);
            var result = _unitofWork.Save();
            return Created("GetAllCompanies", result);
        }
        //[HttpPut]
        //public async Task<IActionResult> Put(Country entity)
        //{
        //    await _unitofWork.CountryRepo.Update(entity);
        //    var result = _unitofWork.Save();
        //    return Ok(result);
        //}

        // PUT: api/CompanyOwnerships
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Country entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Country data.");

            await _unitofWork.CountryRepo.Update(entity);
            var result = _unitofWork.Save();

            return Ok(entity);
        }

        // DELETE: api/CompanyOwnerships
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _unitofWork.CountryRepo.GetById(id);
            if (country == null)
                return NotFound($"Country with ID {id} not found.");

            _unitofWork.CountryRepo.Delete(country);
            _unitofWork.Save();

            return NoContent();
        }
    }
}
