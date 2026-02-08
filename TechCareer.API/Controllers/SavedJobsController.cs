using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class SavedJobsController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public SavedJobsController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var saveJob = await _unitofWork.SavedJobsRepo.GetAll();
         return Ok(saveJob);
      }
      [HttpGet("GetAllSavedJob/{id}")]
      public async Task<IActionResult> GetAllSavedJob(int id)
      {
         var savedJobs = await _unitofWork.SavedJobsRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(savedJobs);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var savedJobs = await _unitofWork.SavedJobsRepo.GetById(id);
         return Ok(savedJobs);
      }
      [HttpPost]
      public async Task<IActionResult> Post([FromBody] SavedJobs entity)
      {
         if (entity == null)
         {
            return BadRequest("Saved Jobs Object is Null");
         }
         await _unitofWork.SavedJobsRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllSavedJob", result);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] SavedJobs entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("CareerEvent Object Is Null");
         }
         await _unitofWork.SavedJobsRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var savedJobs = await _unitofWork.SavedJobsRepo.GetById(id);
         if (savedJobs == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.SavedJobsRepo.Delete(savedJobs);
         var result = _unitofWork.Save();

         return Ok(result);
      }
   }
}
