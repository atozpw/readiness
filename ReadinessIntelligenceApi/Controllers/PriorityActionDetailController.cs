using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriorityActionDetailController : ControllerBase
    {
        private readonly DataContext _context;

        public PriorityActionDetailController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PriorityActionDetail>> Get() {
            return Ok(_context.PriorityActionDetails.OrderByDescending(d => d.UpdatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<PriorityActionDetail> Get(int id) {
            var priorityactiondetail = _context.PriorityActionDetails.Find(id);

            if (priorityactiondetail == null)
                return BadRequest("Priority Action Detail not found.");

            return Ok(priorityactiondetail);
        }

        [HttpPost]
        public ActionResult<List<PriorityActionDetail>> Create(PriorityActionDetail request)
        {
            _context.PriorityActionDetails.Add(request);

            _context.SaveChanges();

            return Ok(_context.PriorityActionDetails.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<PriorityActionDetail>> Update(int id, PriorityActionDetail request)
        {
            var priorityactiondetail = _context.PriorityActionDetails.Find(id);

            if (priorityactiondetail == null)
                return BadRequest("Priority Action Detail not found.");

            priorityactiondetail.PriorityActionId = request.PriorityActionId;
            priorityactiondetail.Action = request.Action;
            priorityactiondetail.EstimatedCost = request.EstimatedCost;
            priorityactiondetail.EstimatedPeriod = request.EstimatedPeriod;
            priorityactiondetail.File = request.File;

            _context.SaveChanges();

            return Ok(_context.PriorityActionDetails.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<PriorityActionDetail>> Delete(int id)
        {
            var priorityactiondetail = _context.PriorityActionDetails.Find(id);

            if (priorityactiondetail == null)
                return BadRequest("Priority Action Detail not found.");

            _context.PriorityActionDetails.Remove(priorityactiondetail);

            _context.SaveChanges();

            return Ok(_context.PriorityActionDetails.ToList());
        }

    }
}