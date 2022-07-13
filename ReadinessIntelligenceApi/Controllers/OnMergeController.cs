using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnMergeController : ControllerBase
    {
        private readonly DataContext _context;

        public OnMergeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{planId}/{domainId}")]
        public ActionResult<List<OnMerge>> Get(int planId, int domainId) {
            var onmerges = _context
                .OnMerges
                .OrderBy(d => d.CreatedAt)
                .ToList();

            return Ok(onmerges);
        }

        [HttpPost]
        public ActionResult<List<OnMerge>> Create(OnMerge request)
        {
            _context.OnMerges.Add(request);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<OnMerge>> Delete(int id)
        {
            var onmerge = _context.OnMerges.Where(d => d.DraftResponseId == id).First();

            if (onmerge == null)
                return BadRequest("Domain not found.");

            _context.OnMerges.Remove(onmerge);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}/DeleteAll")]
        public ActionResult<List<OnMerge>> DeleteAll(int id)
        {
            var onmerges = _context.OnMerges.Where(d => d.DomainId == id).ToList();

            foreach(OnMerge onmerge in onmerges) {
                _context.OnMerges.Remove(onmerge);
            }
            
            _context.SaveChanges();

            return Ok();
        }

    }
}