using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfilesController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public CompanyProfilesController(IUnitofWork unitofWork)
        {
            this._unitofWork= unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _unitofWork.CompanyRepo.GetAll();
            return Ok(companies);
        }
        [HttpGet("GetAllCompanies/{id}")]
        
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var companies = await _unitofWork.CompanyRepo.GetAll(c=>c.Id.Equals(id),null);
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get( int id)
        {
            var companies = await _unitofWork.CompanyRepo.GetById(id);
            return Ok(companies);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CompanyProfile entity)
        {
             await _unitofWork.CompanyRepo.Add(entity);
           var result=  _unitofWork.Save();
            return Created("GetAllCompanies",result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(CompanyProfile entity)
        {
            await _unitofWork.CompanyRepo.Update(entity);
            var result = _unitofWork.Save();
            return Ok( result);
        }

    }
}

