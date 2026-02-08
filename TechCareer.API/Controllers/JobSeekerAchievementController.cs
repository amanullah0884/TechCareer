using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Models.PaymentMethod;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerAchievementController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public JobSeekerAchievementController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var JobSeekerAchievements = await _unitofWork.JobSeekerAchievementRepo.GetAll();
            return Ok(JobSeekerAchievements);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var JobSeekerAchievements = await _unitofWork.JobSeekerAchievementRepo.GetById(id);
            if (JobSeekerAchievements == null)
                return NotFound("payment Transcation not found");
            return Ok(JobSeekerAchievements);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] JobSeekerAchievement JobSeekerAchievement)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.JobSeekerAchievementRepo.Add(JobSeekerAchievement);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JobSeekerAchievement JobSeekerAchievement)
        {
            var existing = await _unitofWork.paymentTransactionRepo.GetById(JobSeekerAchievement.Id);
            if (existing == null)
                return NotFound("Payment Transcation Not found");
            await _unitofWork.JobSeekerAchievementRepo.Update(JobSeekerAchievement);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.JobSeekerAchievementRepo.GetById(id);
            if (entity == null)
                return NotFound("Payment Transcation Not found");
            _unitofWork.JobSeekerAchievementRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
