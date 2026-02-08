using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class JobSeekerInfoController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public JobSeekerInfoController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var jobSeekerInfo = await _unitofWork.JobSeekerInfoRepo.GetAll();
         return Ok(jobSeekerInfo);
      }

      [HttpGet("GetAllJobSeekerInfo/{id}")]
      public async Task<IActionResult> GetAllJobSeekerInfo(int id)
      {
         var jobSeekerInfo = await _unitofWork.JobSeekerInfoRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(jobSeekerInfo);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var jobSeekerInfo = await _unitofWork.JobSeekerInfoRepo.GetById(id);
         return Ok(jobSeekerInfo);
      }

      [HttpPost]
      public async Task<IActionResult> Post([FromBody] JobSeekerInformation entity)
      {
         if (entity == null)
         {
            return BadRequest("Job Seeker Information Object is Null");
         }
         await _unitofWork.JobSeekerInfoRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllJobSeekerInfo", result);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] JobSeekerInformation entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("Job Seeker Information Object Is Null");
         }
         await _unitofWork.JobSeekerInfoRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var jobSeekerInfo = await _unitofWork.JobSeekerInfoRepo.GetById(id);
         if (jobSeekerInfo == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.JobSeekerInfoRepo.Delete(jobSeekerInfo);
         var result = _unitofWork.Save();

         return Ok(result);
      }
   }
}
