using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PreferredJobInfoController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public PreferredJobInfoController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var preferredJobInfo = await _unitofWork.PreferredJobInfoRepo.GetAll();
         return Ok(preferredJobInfo);
      }
      [HttpGet("GetAllPreferredJobInfo/{id}")]
      public async Task<IActionResult> GetAllPreferredJobInfo(int id)
      {
         var preferredJobInfo = await _unitofWork.PreferredJobInfoRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(preferredJobInfo);
      }
      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var preferredJobInfo = await _unitofWork.PreferredJobInfoRepo.GetById(id);
         return Ok(preferredJobInfo);
      }
      [HttpPost]
      public async Task<IActionResult> Post([FromBody] PreferredJobInformation entity)
      {
         if (entity == null)
         {
            return BadRequest("Preferred Job Information Object is Null");
         }
         await _unitofWork.PreferredJobInfoRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllPreferredJobInfo", result);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] PreferredJobInformation entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("Preferred Job Information Object Is Null");
         }
         await _unitofWork.PreferredJobInfoRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }
      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var preferredJobInfo = await _unitofWork.PreferredJobInfoRepo.GetById(id);
         if (preferredJobInfo == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.PreferredJobInfoRepo.Delete(preferredJobInfo);
         var result = _unitofWork.Save();

         return Ok(result);
      }
   }
}
