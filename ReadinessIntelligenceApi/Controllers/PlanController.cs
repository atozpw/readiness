using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly DataContext _context;

        public PlanController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Plan>> Get() {
            return Ok(_context.Plans.OrderBy(d => d.UpdatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Plan> Get(int id) {
            var plan = _context.Plans.Find(id);

            if (plan == null)
                return BadRequest("Plan not found.");

            return Ok(plan);
        }

        [HttpPost]
        public ActionResult<List<Plan>> Create(Plan request)
        {
            _context.Plans.Add(request);

            _context.SaveChanges();

            return Ok(_context.Plans.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<Plan>> Update(int id, Plan request)
        {
            var plan = _context.Plans.Find(id);

            if (plan == null)
                return BadRequest("Plan not found.");

            plan.Name = request.Name;

            _context.SaveChanges();

            return Ok(_context.Plans.ToList());
        }

        [HttpPut("{id}/IsSubmitted")]
        public ActionResult<List<Plan>> UpdateIsSubmitted(int id, Plan request)
        {
            var plan = _context.Plans.Find(id);

            if (plan == null)
                return BadRequest("Plan not found.");

            plan.IsSubmitted = request.IsSubmitted;

            _context.SaveChanges();

            return Ok(_context.Plans.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Plan>> Delete(int id)
        {
            var plan = _context.Plans.Find(id);

            if (plan == null)
                return BadRequest("Plan not found.");

            _context.Plans.Remove(plan);

            _context.SaveChanges();

            return Ok(_context.Plans.ToList());
        }

    }
}