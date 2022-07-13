using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriorityActionController : ControllerBase
    {
        private readonly DataContext _context;

        public PriorityActionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{planId}")]
        public ActionResult<List<DraftResponse>> Get(int planId) {
            var draft_responses = _context
                .DraftResponses
                .Where(d => 
                    d.PlanId == planId && 
                    (d.IsSelected == false | d.DomainId == 0 | d.DomainId == null)
                )
                .ToList();

            return Ok(draft_responses);
        }

        [HttpGet("{planId}/FilterDomain")]
        public ActionResult<List<Domain>> GetDomain(int planId) {
            var domains = _context
                .Domains
                .Include(x => x.DraftResponses)
                .ToList();

            return Ok(domains);
        }

    }
}