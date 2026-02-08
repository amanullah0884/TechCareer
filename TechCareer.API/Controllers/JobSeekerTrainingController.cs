using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class JobSeekerTrainingController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public JobSeekerTrainingController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var jobSeekerTraining = await _unitofWork.JobRequiredSkillRepo.GetAll();
         return Ok(jobSeekerTraining);
      }
      [HttpGet("GetAllJobSeekerTraining/{id}")]
      public async Task<IActionResult> GetAllJobSeekerTraining(int id)
      {
         var jobSeekerTraining = await _unitofWork.JobSeekerTrainingRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(jobSeekerTraining);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var jobSeekerTraining = await _unitofWork.JobSeekerTrainingRepo.GetById(id);
         return Ok(jobSeekerTraining);
      }
      [HttpPost]
      public async Task<IActionResult> Post([FromBody] JobSeekerTraining entity)
      {
         if (entity == null)
         {
            return BadRequest("Job Seeker Training Object is Null");
         }
         await _unitofWork.JobSeekerTrainingRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllJobSeekerTraining", result);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] JobSeekerTraining entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("Job Seeker Training Object Is Null");
         }
         await _unitofWork.JobSeekerTrainingRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var jobTraining = await _unitofWork.JobSeekerTrainingRepo.GetById(id);
         if (jobTraining == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.JobSeekerTrainingRepo.Delete(jobTraining);
         var result = _unitofWork.Save();
         //dsf
         return Ok(result);
      }
   }
}
