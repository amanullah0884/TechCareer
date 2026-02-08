using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
using System.Threading.Tasks;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class JobNaturesController : ControllerBase
   {
      private readonly IUnitofWork _unitOfWork;

      public JobNaturesController(IUnitofWork unitOfWork)
      {
         _unitOfWork = unitOfWork;
      }

      // GET: api/JobNatures
      [HttpGet]
      public async Task<IActionResult> GetAllJobNatures()
      {
         var jobNatures = await _unitOfWork.JobNatureRepo.GetAll(); 
         return Ok(jobNatures);
      }

      // GET: api/JobNatures
      [HttpGet("{id}")]
      public async Task<IActionResult> GetJobNatureById(int id)
      {
         var jobNature = await _unitOfWork.JobNatureRepo.GetById(id);
         if (jobNature == null)
            return NotFound();
         return Ok(jobNature);
      }

      // POST: api/JobNatures
      [HttpPost]
      public async Task<IActionResult> CreateJobNature([FromBody] JobNature jobNature)
      {
         if (!ModelState.IsValid)
            return BadRequest(ModelState);

         await _unitOfWork.JobNatureRepo.Add(jobNature); 
         await _unitOfWork.SaveAsync(); 

         return CreatedAtAction(nameof(GetJobNatureById), new { id = jobNature.Id }, jobNature);
      }

      // PUT: api/JobNatures
      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateJobNature(int id, [FromBody] JobNature jobNature)
      {
         var existing = await _unitOfWork.JobNatureRepo.GetById(id);
         if (existing == null)
            return NotFound();

         existing.JobNatureCategory = jobNature.JobNatureCategory;

         await _unitOfWork.JobNatureRepo.Update(existing); 
         await _unitOfWork.SaveAsync();

         return Ok(existing);
      }

      // DELETE: api/JobNatures
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteJobNature(int id)
      {
         var jobNature = await _unitOfWork.JobNatureRepo.GetById(id); 
         if (jobNature == null)
            return NotFound();

         _unitOfWork.JobNatureRepo.Delete(jobNature); 
         await _unitOfWork.SaveAsync();

         return NoContent();
      }
   }
}
