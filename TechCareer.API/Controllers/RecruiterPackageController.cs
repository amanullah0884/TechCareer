using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.BillingInformation;
using TechCareer_DLL.Models.PaymentMethod;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterPackageController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public RecruiterPackageController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var RecruiterPackages=await _unitofWork.RecruiterPackageRepo.GetAll();
            return Ok(RecruiterPackages);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var RecruiterPackages= await _unitofWork.RecruiterPackageRepo.GetById(id);  
            if(RecruiterPackages == null)
                return NotFound("Recruiter Packages not found");
            return Ok(RecruiterPackages);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecruiterPackage recruiterPackage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.RecruiterPackageRepo.Add(recruiterPackage);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RecruiterPackage recruiterPackage)
        {
            var existing = await _unitofWork.paymentTransactionRepo.GetById(recruiterPackage.Id);
            if (existing == null)
                return NotFound("Payment Transcation Not found");
            await _unitofWork.RecruiterPackageRepo.Update(recruiterPackage);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.RecruiterPackageRepo.GetById(id);
            if (entity == null)
                return NotFound("Payment Transcation Not found");
            _unitofWork.RecruiterPackageRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
