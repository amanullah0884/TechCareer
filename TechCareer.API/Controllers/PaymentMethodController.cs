using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.PaymentMethod;
using System.Threading.Tasks;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;

        public PaymentMethodController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paymentMethods = await _unitofWork.PaymentMethodRepo.GetAll();
            return Ok(paymentMethods);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var paymentMethod = await _unitofWork.PaymentMethodRepo.GetById(id);
            if (paymentMethod == null)
                return NotFound("Payment method not found");

            return Ok(paymentMethod);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PaymentMethod paymentMethod)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _unitofWork.PaymentMethodRepo.Add(paymentMethod);
            var result = _unitofWork.Save();

            return CreatedAtAction(nameof(Get), new { id = paymentMethod.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PaymentMethod paymentMethod)
        {
            var existing = await _unitofWork.PaymentMethodRepo.GetById(paymentMethod.Id);
            if (existing == null)
                return NotFound("Payment method not found");

            await _unitofWork.PaymentMethodRepo.Update(paymentMethod);
            var result = _unitofWork.Save();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.PaymentMethodRepo.GetById(id);
            if (entity == null)
                return NotFound("Payment method not found");

            _unitofWork.PaymentMethodRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
