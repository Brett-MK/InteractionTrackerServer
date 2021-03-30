using InteractionTrackerServer.Data;
using InteractionTrackerServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace InteractionTrackerServer.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IInteractionRepo _interactionRepo;

        public ReportsController(IInteractionRepo interactionRepo)
        {
            _interactionRepo = interactionRepo;
        }

        // GET /api/reports/daily
        [Route("/daily")]
        [HttpGet]
        public ActionResult<Report> GetDailyReport()
        {
            var interactions = _interactionRepo.GetAllInteractions();

            return Ok(interactions);
        }

        // GET /api/reports/monthly
        [Route("/monthly")]
        [HttpGet]
        public ActionResult<Report> GetMonthlyReport()
        {
            var interactions = _interactionRepo.GetAllInteractions();

            return Ok(interactions);
        }
    }
}
