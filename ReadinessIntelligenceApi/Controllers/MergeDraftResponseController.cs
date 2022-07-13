using Microsoft.AspNetCore.Mvc;
using ReadinessIntelligenceApi.Models;

namespace ReadinessIntelligenceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeDraftResponseController : ControllerBase
    {
        private readonly DataContext _context;

        public MergeDraftResponseController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<List<MergeDraftResponse>> Create(MergeDraftResponse request)
        {
            _context.MergeDraftResponses.Add(request);

            _context.SaveChanges();

            return Ok();
        }

    }
}