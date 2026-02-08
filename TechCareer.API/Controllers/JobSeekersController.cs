using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class JobSeekersController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public JobSeekersController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var jobSeeker = await _unitofWork.JobSeekerRepo.GetAll();
         return Ok(jobSeeker);
      }
      [HttpGet("GetAllJobSeeker/{id}")]
      public async Task<IActionResult> GetAllJobSeeker(int id)
      {
         var jobSeeker = await _unitofWork.JobSeekerRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(jobSeeker);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var jobSeeker = await _unitofWork.JobSeekerRepo.GetById(id);
         return Ok(jobSeeker);
      }
      [HttpPost]
      public async Task<IActionResult> Post([FromBody] JobSeeker entity)
      {
         if (entity == null)
         {
            return BadRequest("Job Seeker Object is Null");
         }
         await _unitofWork.JobSeekerRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllJobSeeker", result);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] JobSeeker entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("job Seeker Object Is Null");
         }
         await _unitofWork.JobSeekerRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var jobSeeker = await _unitofWork.JobSeekerRepo.GetById(id);
         if (jobSeeker == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.JobSeekerRepo.Delete(jobSeeker);
         var result = _unitofWork.Save();

         return Ok(result);
      }

   }
}


   