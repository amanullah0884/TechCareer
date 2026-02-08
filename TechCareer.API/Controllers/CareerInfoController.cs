using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class CareerInfoController : ControllerBase
   {
      private readonly IUnitofWork _unitofWork;
      public CareerInfoController(IUnitofWork unitofWork)
      {
         _unitofWork = unitofWork;
      }

      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         var careerInfo = await _unitofWork.CareerInformationRepo.GetAll();
         return Ok(careerInfo);
      }

      [HttpGet("GetAllCareerInfo/{id}")]
      public async Task<IActionResult> GetAllCareerInfo(int id)
      {
         var careerInfo = await _unitofWork.CareerEventRepo.GetAll(c => c.Id.Equals(id), null);
         return Ok(careerInfo);
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var CareerInfo = await _unitofWork.CareerInformationRepo.GetById(id);
         return Ok(CareerInfo);
      }

      [HttpPost]
      public async Task<IActionResult> Post([FromBody] CareerInformation entity)
      {
         if (entity == null)
         {
            return BadRequest("CareerInformation Object is Null");
         }
         await _unitofWork.CareerInformationRepo.Add(entity);
         var result = _unitofWork.Save();
         return Created("GetAllCareerInfo", result);
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] CareerInformation entity)
      {
         if (entity == null || entity.Id == null)
         {
            return BadRequest("Career Information Object Is Null");
         }
         await _unitofWork.CareerInformationRepo.Update(entity);
         var result = _unitofWork.Save();
         return Ok(result);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> Delete(int id)
      {
         var careerInfo = await _unitofWork.CareerInformationRepo.GetById(id);
         if (careerInfo == null)
         {
            return BadRequest("Delete Object Is Null");
         }

         _unitofWork.CareerInformationRepo.Delete(careerInfo);
         var result = _unitofWork.Save();

         return Ok(result);
      }

   }
}

