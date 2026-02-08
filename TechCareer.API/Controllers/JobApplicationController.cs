using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class JobApplicationController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public JobApplicationController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var jobApp = await _unitofWork.JobApplicationRepo.GetAll();
         return Ok(jobApp);
      }
      [HttpGet("GetAllJobapply/{id}")]
      public async Task<IActionResult> GetAllJobapply(int id)
      {
         var jobApp = await _unitofWork.JobApplicationRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(jobApp);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var jobApp = await _unitofWork.JobApplicationRepo.GetById(id);
         return Ok(jobApp);
      }

      [HttpPost]
      public async Task<IActionResult> Post([FromBody] JobApplication entity)
      {
         if (entity == null)
         {
            return BadRequest("Job Application Object is Null");
         }
         await _unitofWork.JobApplicationRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllJobapply", result);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] JobApplication entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("Job Application Object Is Null");
         }
         await _unitofWork.JobApplicationRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var jobApp = await _unitofWork.JobApplicationRepo.GetById(id);
         if (jobApp == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.JobApplicationRepo.Delete(jobApp);
         var result = _unitofWork.Save();

         return Ok(result);
      }

   }
}
