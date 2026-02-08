using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
namespace TechCareer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyOwnershipsController : ControllerBase
    {
        private readonly IUnitofWork _unitOfWork;

        public CompanyOwnershipsController(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/CompanyOwnerships
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ownerships = await _unitOfWork.CompanyOwnershipRepo.GetAll();
            return Ok(ownerships);
        }

        // GET: api/CompanyOwnerships
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ownership = await _unitOfWork.CompanyOwnershipRepo.GetById(id);
            if (ownership == null)
                return NotFound($"CompanyOwnership with ID {id} not found.");

            return Ok(ownership);
        }

        // POST: api/CompanyOwnerships
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyOwnership entity)
        {
            if (entity == null)
                return BadRequest("CompanyOwnership object is null.");

            await _unitOfWork.CompanyOwnershipRepo.Add(entity);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT: api/CompanyOwnerships
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CompanyOwnership entity)
        {
            if (entity == null || entity.Id != id)
                return BadRequest("Invalid CompanyOwnership data.");

            await _unitOfWork.CompanyOwnershipRepo.Update(entity);
            _unitOfWork.Save();

            return Ok(entity);
        }

        // DELETE: api/CompanyOwnerships
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ownership = await _unitOfWork.CompanyOwnershipRepo.GetById(id);
            if (ownership == null)
                return NotFound($"CompanyOwnership with ID {id} not found.");

            _unitOfWork.CompanyOwnershipRepo.Delete(ownership);
            _unitOfWork.Save();

            return NoContent();
        }
    }
}

