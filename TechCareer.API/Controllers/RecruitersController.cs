using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;

namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitersController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;
        public RecruitersController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Recruiters
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recuiters = await _unitOfWork.RecruiterRepo.GetAll();
            return Ok(recuiters);

        }


        [HttpGet("GetAllRecuiters{id}")]
        public async Task<IActionResult>GetAllRecuiters(int id)
        {
            var recruiters = await _unitOfWork.RecruiterRepo.GetAll(c=>c.Id.Equals(id),null);
            return Ok(recruiters);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecruiterById(int id)
        {
            var recruiter = await _unitOfWork.RecruiterRepo.GetById(id);
            if (recruiter == null)
                return NotFound();
            return Ok(recruiter);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Recruiter entity) 
        {
            if (entity==null)
            {
                return BadRequest("Recruiter Object is NUll");

            }
            await _unitOfWork.RecruiterRepo.Add(entity);
            var result= _unitOfWork.SaveAsync();
            return Created("Create complete",result);



        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Recruiter entity)
        {
         if(entity==null|| id != entity.Id)
            {
                return BadRequest(" Recruiter Object  is NUll");
            }
            await _unitOfWork.RecruiterRepo.Update(entity);
            var result = _unitOfWork.Save();
            return Ok(entity);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recruiter = await _unitOfWork.RecruiterRepo.GetById(id);

            if (recruiter == null) {
                return BadRequest("object Is null");

            }
            _unitOfWork.RecruiterRepo.Delete(recruiter);
            var result= _unitOfWork.Save();
            return Ok(result);



        }

      

    }
}
