using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DomainController : ControllerBase
    {
        private readonly DataContext _context;

        public DomainController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Domain>> Get() {
            return Ok(_context.Domains.OrderByDescending(d => d.UpdatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Domain> Get(int id) {
            var domain = _context.Domains.Find(id);

            if (domain == null)
                return BadRequest("Domain not found.");

            return Ok(domain);
        }

        [HttpPost]
        public ActionResult<List<Domain>> Create(Domain request)
        {
            _context.Domains.Add(request);

            _context.SaveChanges();

            return Ok(_context.Domains.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<Domain>> Update(int id, Domain request)
        {
            var domain = _context.Domains.Find(id);

            if (domain == null)
                return BadRequest("Domain not found.");

            domain.Name = request.Name;

            _context.SaveChanges();

            return Ok(_context.Domains.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Domain>> Delete(int id)
        {
            var domain = _context.Domains.Find(id);

            if (domain == null)
                return BadRequest("Domain not found.");

            _context.Domains.Remove(domain);

            _context.SaveChanges();

            return Ok(_context.Domains.ToList());
        }

    }
}