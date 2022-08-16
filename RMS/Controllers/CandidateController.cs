using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS.Data;
using RMS.Models;

namespace RMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly CandidateDbContext _candidateDbContext;
        public CandidateController(CandidateDbContext candidateDbContext)
        {
            _candidateDbContext = candidateDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidate()
        {
            var candidates = await _candidateDbContext.Candidates.ToListAsync();
            
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidateRequest)
        {
            candidateRequest.ID = Guid.NewGuid();

            await _candidateDbContext.Candidates.AddAsync(candidateRequest);
            await _candidateDbContext.SaveChangesAsync();

            return Ok(candidateRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCandidate([FromRoute] Guid id)
        {
            var candidate = await _candidateDbContext.Candidates.FirstOrDefaultAsync(x => x.ID == id);
        
            if(candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCandidate([FromRoute] Guid id, Candidate updateCandidateRequest)
        {
            var candidate = await _candidateDbContext.Candidates.FindAsync(id);

            if(candidate == null)

            {
                return NotFound();
            }

            candidate.FirstName = updateCandidateRequest.FirstName;
            candidate.LastName = updateCandidateRequest.LastName;
            candidate.Email = updateCandidateRequest.Email;
            candidate.Phone = updateCandidateRequest.Phone;
            candidate.Department = updateCandidateRequest.Department;

            await _candidateDbContext.SaveChangesAsync();

            return Ok(candidate);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCandidate([FromRoute] Guid id)
        {
            var candidate = await _candidateDbContext.Candidates.FindAsync(id);
        
            if(candidate == null)
            {
                return NotFound();
            }

            _candidateDbContext.Candidates.Remove(candidate);
            await _candidateDbContext.SaveChangesAsync();

            return Ok(candidate);
        }

    }
}
