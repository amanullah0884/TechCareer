using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerCertificateController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public JobSeekerCertificateController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var certificates = await _unitOfWork.JobSeekerCertificateRepo.GetAll();
            return Ok(certificates);
        }

      
        [HttpGet("GetAllCertificates/{id}")]
        public async Task<IActionResult> GetAllCertificates(int id)
        {
            var list = await _unitOfWork.JobSeekerCertificateRepo
                        .GetAll(c => c.Id == id, null);

            return Ok(list);
        }

   
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var certificate = await _unitOfWork.JobSeekerCertificateRepo.GetById(id);

            if (certificate == null)
                return NotFound("Certificate not found");

            return Ok(certificate);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobSeekerCertification entity)
        {
            if (entity == null)
                return BadRequest("Certificate object is null");

            await _unitOfWork.JobSeekerCertificateRepo.Add(entity);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobSeekerCertification entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid certificate Id");

            await _unitOfWork.JobSeekerCertificateRepo.Update(entity);
            await _unitOfWork.SaveAsync();

            return Ok(entity);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var certificate = await _unitOfWork.JobSeekerCertificateRepo.GetById(id);

            if (certificate == null)
                return NotFound("Certificate not found");

            _unitOfWork.JobSeekerCertificateRepo.Delete(certificate);
            await _unitOfWork.SaveAsync();

            return Ok("Deleted successfully");
        }
    }
}
