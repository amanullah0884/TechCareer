using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.BillingInformation;
using TechCareer_DLL.Models.PaymentMethod;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterSubscriptionController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public RecruiterSubscriptionController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var RecruiterSubscriptions=await _unitofWork.RecruiterSubscriptionRepo.GetAll();
            return Ok(RecruiterSubscriptions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var RecruiterSubscriptions = await _unitofWork.RecruiterSubscriptionRepo.GetById(id);
            if (RecruiterSubscriptions == null)
                return NotFound("payment Transcation not found");
            return Ok(RecruiterSubscriptions);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecruiterSubscription recruiterSubscription)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.RecruiterSubscriptionRepo.Add(recruiterSubscription);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecruiterSubscription recruiterSubscription)
        {
            var existing = await _unitofWork.RecruiterSubscriptionRepo.GetById(recruiterSubscription.Id);
            if (existing == null)
                return NotFound("Payment Transcation Not found");
            await _unitofWork.RecruiterSubscriptionRepo.Update(recruiterSubscription);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.RecruiterSubscriptionRepo.GetById(id);
            if (entity == null)
                return NotFound("Payment Transcation Not found");
            _unitofWork.RecruiterSubscriptionRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
