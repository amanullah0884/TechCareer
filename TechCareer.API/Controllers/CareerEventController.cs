using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerEventController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public CareerEventController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var CareerEvent = await _unitofWork.CareerEventRepo.GetAll();
            return Ok(CareerEvent);
        }
        [HttpGet("GetAllCareerEvent/{id}")]
        public async Task<IActionResult> GetAllCareerEvent(int id)
        {
            var CareerEvent = await _unitofWork.CareerEventRepo.GetAll(c => c.Id.Equals(id), null);
            return Ok(CareerEvent);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var CareerEvent=await _unitofWork.CareerEventRepo.GetById(id);
            return Ok(CareerEvent);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CareerEvent entity)
        {
            if (entity == null)
            {
                return BadRequest("CareerEvent Object is Null");
            }
            await _unitofWork.CareerEventRepo.Add(entity);
            var result = _unitofWork.Save();
            return Created("GetAllCareerEvent",result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CareerEvent entity)
        {
            if (entity == null || entity.Id == null)
            {
                return BadRequest("CareerEvent Object Is Null");
            }
            await _unitofWork.CareerEventRepo.Update(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var careerEvent = await _unitofWork.CareerEventRepo.GetById(id);
            if (careerEvent==null)
            {
                return BadRequest("Delete Object Is Null");
            }

            _unitofWork.CareerEventRepo.Delete(careerEvent);
            var result = _unitofWork.Save();
            
            return Ok(result);
        }

    }
}
