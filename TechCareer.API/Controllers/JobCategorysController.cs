using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.JobModule;
using TechCareer_DLL.Utility;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategorysController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ModelMessage modelMessage;
        public JobCategorysController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobCategories = await _unitofWork.JobCategoryRepo.GetAll();
            return Ok(jobCategories);
            //var companies = await _unitofWork.CompanyRepo.GetAll();
            //return Ok(companies);
        }
        [HttpGet("GetAllCompanies/{id}")]
        public async Task<IActionResult> GetAllCompanies(int id)
        {
            var jobCategories = await _unitofWork.JobCategoryRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(jobCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var jobCategory = await _unitofWork.JobCategoryRepo.GetById(id);
            return Ok(jobCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Post(JobCategory entity)
        {
            await _unitofWork.JobCategoryRepo.Add(entity);
            var result = _unitofWork.Save();
            return Created("GetAllCompanies", result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(JobCategory entity)
        {
            await _unitofWork.JobCategoryRepo.Update(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var jobCategory = await _unitofWork.JobCategoryRepo.GetById(id);
        //    if (jobCategory == null)
        //    {
        //        return NotFound();
        //    }
        //    await _unitofWork.JobCategoryRepo.Delete(jobCategory);
        //    var result = _unitofWork.Save();
        //    return Ok(result);
        //}
    }
}
