using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanDocumentController : ControllerBase
    {
        private readonly DataContext _context;

        public PlanDocumentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PlanDocument>> Get() {
            return Ok(_context.PlanDocuments.OrderBy(d => d.CreatedAt).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<PlanDocument> Get(int id) {
            var plandocument = _context.PlanDocuments.Find(id);

            if (plandocument == null)
                return BadRequest("Plan Document not found.");

            return Ok(plandocument);
        }

        [HttpPost]
        public ActionResult<List<PlanDocument>> Create(PlanDocument request)
        {
            _context.PlanDocuments.Add(request);

            _context.SaveChanges();

            return Ok(_context.PlanDocuments.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult<List<PlanDocument>> Update(int id, PlanDocument request)
        {
            var plandocument = _context.PlanDocuments.Find(id);

            if (plandocument == null)
                return BadRequest("Plan Document not found.");

            plandocument.Name = request.Name;

            _context.SaveChanges();

            return Ok(_context.PlanDocuments.ToList());
        }

        [HttpDelete("{id}")]
        public ActionResult<List<PlanDocument>> Delete(int id)
        {
            var plandocument = _context.PlanDocuments.Find(id);

            if (plandocument == null)
                return BadRequest("Plan Document not found.");

            _context.PlanDocuments.Remove(plandocument);

            _context.SaveChanges();

            return Ok(_context.PlanDocuments.ToList());
        }

    }
}