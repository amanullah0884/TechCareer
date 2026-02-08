using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class JobSeekerEducationController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public JobSeekerEducationController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var jobSeekerEdu = await _unitofWork.JobSeekerEducationRepo.GetAll();
         return Ok(jobSeekerEdu);
      }
      [HttpGet("GetAllJobSeekerEducation/{id}")]
      public async Task<IActionResult> GetAllJobSeekerEducation(int id)
      {
         var jobSeekerEdu = await _unitofWork.JobSeekerEducationRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(jobSeekerEdu);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var jobSeekerEdu = await _unitofWork.JobSeekerEducationRepo.GetById(id);
         return Ok(jobSeekerEdu);
      }
      [HttpPost]
      public async Task<IActionResult> Post([FromBody] JobSeekerEducation entity)
      {
         if (entity == null)
         {
            return BadRequest("Job Seeker Education Object is Null");
         }
         await _unitofWork.JobSeekerEducationRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllJobSeekerEducation", result);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] JobSeekerEducation entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("Job Seeker Education Object Is Null");
         }
         await _unitofWork.JobSeekerEducationRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var jobSeekerEdu = await _unitofWork.JobSeekerEducationRepo.GetById(id);
         if (jobSeekerEdu == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.JobSeekerEducationRepo.Delete(jobSeekerEdu);
         var result = _unitofWork.Save();

         return Ok(result);
      }
   }
}
