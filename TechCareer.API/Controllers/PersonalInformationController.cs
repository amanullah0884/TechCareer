using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        public PersonalInformationController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  PersonalInformations = await _unitofWork.PersonalInformationRepo.GetAll();
            return Ok(PersonalInformations);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var PersonalInformations = await _unitofWork.PersonalInformationRepo.GetById(id);
            if (PersonalInformations == null)
                return NotFound("payment Transcation not found");
            return Ok(PersonalInformations);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PersonalInformation personalInformation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _unitofWork.PersonalInformationRepo.Add(personalInformation);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonalInformation personalInformation)
        {
            var existing = await _unitofWork.PersonalInformationRepo.GetById(personalInformation.Id);
            if (existing == null)
                return NotFound("Payment Transcation Not found");
            await _unitofWork.PersonalInformationRepo.Update(personalInformation);
            var result = _unitofWork.Save();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitofWork.PersonalInformationRepo.GetById(id);
            if (entity == null)
                return NotFound("Payment Transcation Not found");
            _unitofWork.PersonalInformationRepo.Delete(entity);
            var result = _unitofWork.Save();
            return Ok(result);
        }
    }
}
