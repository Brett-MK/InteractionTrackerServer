using InteractionTrackerServer.Data;
using InteractionTrackerServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Controllers
{
    [ApiController]
    [Route("/api/interactions")]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionRepo _interactionRepo;

        public InteractionController(IInteractionRepo interactionRepo)
        {
            _interactionRepo = interactionRepo;
        }

        // GET /api/interactions
        [HttpGet]
        public ActionResult<IEnumerable<Interaction>> GetAllInteractions()
        {
            var interactions = _interactionRepo.GetAllInteractions();

            return Ok(interactions);
        }

        // GET /api/interactions/{id}
        [HttpGet("{id}", Name = "GetInteractionById")]
        public async Task<ActionResult<Interaction>> GetInteractionById(string id)
        {
            var interaction = await _interactionRepo.GetInteractionById(id);

            if (interaction == null)
            {
                return NotFound();
            }

            return Ok(interaction);
        }

        // POST /api/interactions
        [HttpPost]
        public async Task<ActionResult<Interaction>> CreateInteraction(Interaction interaction)
        {
            _interactionRepo.CreateInteraction(interaction);
            await _interactionRepo.SaveChanges();

            return CreatedAtRoute(nameof(GetInteractionById), new { Id = interaction.CallId }, interaction);
        }
    }
}
