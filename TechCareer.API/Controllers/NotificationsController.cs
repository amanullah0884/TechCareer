using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.BillingInformation;
using TechCareer_DLL.Models.SiteSettings;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class NotificationsController : ControllerBase
    {
        private IUnitofWork _unitofWork;
        public NotificationsController (IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllNotifications()
        {
            var notification = await _unitofWork.RecruiterRepo.GetAll();
            return Ok(notification);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(int Id)
        {
            var notification = await _unitofWork.NotificationRepo.GetById(Id);
            if (notification == null)
                return NotFound(" notification not found");
            return Ok(notification);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Notification notification)
        {
            if (ModelState.IsValid)
                return BadRequest(notification);
            await _unitofWork.NotificationRepo.Add(notification);
            var result = _unitofWork.Save();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int Id, [FromBody] Notification notification)
        {
            var existing = await _unitofWork.NotificationRepo.GetById(Id);
            if (existing == null)
                await _unitofWork.NotificationRepo.Update(notification);    
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delet(int Id)
        {
            var notification = await _unitofWork.NotificationRepo.GetById(Id);
            if (notification == null)
                return NotFound("Payment Transcation Not found");
            _unitofWork.NotificationRepo.Delete(notification);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
