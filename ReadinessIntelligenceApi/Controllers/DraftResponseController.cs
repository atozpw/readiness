using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DraftResponseController : ControllerBase
    {
        private readonly DataContext _context;

        public DraftResponseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<DraftResponse>> Get() {
            return Ok(_context.DraftResponses.OrderByDescending(d => d.UpdatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<DraftResponse> Get(int id) {
            var draft_response = _context.DraftResponses.Find(id);

            if (draft_response == null)
                return BadRequest("Draft Response not found.");

            return Ok(draft_response);
        }

        [HttpPost]
        public ActionResult<List<DraftResponse>> Create(DraftResponse request)
        {
            _context.DraftResponses.Add(request);

            _context.SaveChanges();

            return Ok(_context.DraftResponses.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<DraftResponse>> Update(int id, DraftResponse request)
        {
            var draft_response = _context.DraftResponses.Find(id);

            if (draft_response == null)
                return BadRequest("Draft Response not found.");

            draft_response.Action = request.Action;
            draft_response.EstimatedCost = request.EstimatedCost;

            _context.SaveChanges();

            return Ok(_context.DraftResponses.ToList());
        }

        [HttpPut("{id}/IsSelected")]
        public ActionResult<List<DraftResponse>> UpdateIsSelected(int id, DraftResponse request)
        {
            var draft_response = _context.DraftResponses.Find(id);

            if (draft_response == null)
                return BadRequest("Draft Response not found.");

            draft_response.IsSelected = request.IsSelected;

            _context.SaveChanges();

            return Ok(_context.DraftResponses.ToList());
        }

        [HttpPut("{id}/SetDomainId")]
        public ActionResult<List<DraftResponse>> UpdateDomainId(int id, DraftResponse request)
        {
            var draft_response = _context.DraftResponses.Find(id);

            if (draft_response == null)
                return BadRequest("Draft Response not found.");

            draft_response.DomainId = request.DomainId;

            _context.SaveChanges();

            return Ok(_context.DraftResponses.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<DraftResponse>> Delete(int id)
        {
            var draft_response = _context.DraftResponses.Find(id);

            if (draft_response == null)
                return BadRequest("Draft Response not found.");

            _context.DraftResponses.Remove(draft_response);

            _context.SaveChanges();

            return Ok(_context.DraftResponses.ToList());
        }

    }
}