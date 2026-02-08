using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekersKeywordController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobSeekersKeywordController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var keywords = await _unitOfWork.JobSeekersKeywordRepo.GetAll();
            return Ok(keywords);
        }

        [HttpGet("GetAllKeywords/{id}")]
        public async Task<IActionResult> GetAllKeywords(int id)
        {
            var list = await _unitOfWork.JobSeekersKeywordRepo
                        .GetAll(k => k.Id == id, null);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var keyword = await _unitOfWork.JobSeekersKeywordRepo.GetById(id);

            if (keyword == null)
                return NotFound("Keyword not found");

            return Ok(keyword);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobSeekersKeyword entity)
        {
            if (entity == null)
                return BadRequest("Keyword object is null");

            await _unitOfWork.JobSeekersKeywordRepo.Add(entity);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobSeekersKeyword entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid Id or object");

            await _unitOfWork.JobSeekersKeywordRepo.Update(entity);
            await _unitOfWork.SaveAsync();

            return Ok(entity);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var keyword = await _unitOfWork.JobSeekersKeywordRepo.GetById(id);

            if (keyword == null)
                return NotFound("Keyword not found");

            _unitOfWork.JobSeekersKeywordRepo.Delete(keyword);
            await _unitOfWork.SaveAsync();

            return Ok("Deleted successfully");
        }
    }
}
