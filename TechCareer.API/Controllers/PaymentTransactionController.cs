using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.PaymentMethod;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public PaymentTransactionController(IUnitofWork unitofWork)
        {
            _unitofWork=unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PaymentTrancations=await _unitofWork.paymentTransactionRepo.GetAll();
            return Ok(PaymentTrancations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var  PaymentTranscations= await _unitofWork.paymentTransactionRepo.GetById(id);
            if (PaymentTranscations == null) 
                return NotFound("payment Transcation not found");
            return Ok(PaymentTranscations);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaymentTransaction paymentTransaction)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.paymentTransactionRepo.Add(paymentTransaction);
            var result=_unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PaymentTransaction paymentTransaction)
        {
            var existing = await _unitofWork.paymentTransactionRepo.GetById(paymentTransaction.Id);
            if (existing == null)
                return NotFound("Payment Transcation Not found");
            await _unitofWork.paymentTransactionRepo.Update(paymentTransaction);
            var result=_unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var entity = await _unitofWork.paymentTransactionRepo.GetById(id);
            if (entity == null)
                return NotFound("Payment Transcation Not found");
             _unitofWork.paymentTransactionRepo.Delete(entity);
            var result=_unitofWork.Save();
            return Ok(result);
        }
    }
}
