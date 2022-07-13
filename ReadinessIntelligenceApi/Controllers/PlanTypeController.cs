using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public PlanTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PlanType>> Get() {
            return Ok(_context.PlanTypes.OrderBy(d => d.CreatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<PlanType> Get(int id) {
            var plantype = _context.PlanTypes.Find(id);

            if (plantype == null)
                return BadRequest("Plan Type not found.");

            return Ok(plantype);
        }

        [HttpPost]
        public ActionResult<List<PlanType>> Create(PlanType request)
        {
            _context.PlanTypes.Add(request);

            _context.SaveChanges();

            return Ok(_context.PlanTypes.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<PlanType>> Update(int id, PlanType request)
        {
            var plantype = _context.PlanTypes.Find(id);

            if (plantype == null)
                return BadRequest("Plan Type not found.");

            plantype.Name = request.Name;
            plantype.Year = request.Year;

            _context.SaveChanges();

            return Ok(_context.PlanTypes.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<PlanType>> Delete(int id)
        {
            var plantype = _context.PlanTypes.Find(id);

            if (plantype == null)
                return BadRequest("Plan Type not found.");

            _context.PlanTypes.Remove(plantype);

            _context.SaveChanges();

            return Ok(_context.PlanTypes.ToList());
        }

    }
}