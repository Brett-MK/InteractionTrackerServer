using AutoMapper;
using InteractionTrackerServer.Data;
using InteractionTrackerServer.Dtos.CreateDtos;
using InteractionTrackerServer.Dtos.ReadDtos;
using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Controllers
{
    [ApiController]
    [Route("/api/interactions")]
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionRepo _interactionRepo;
        private readonly IMapper _mapper;

        public InteractionsController(IInteractionRepo interactionRepo, IMapper mapper)
        {
            _interactionRepo = interactionRepo;
            _mapper = mapper;
        }

        // GET /api/interactions
        [HttpGet]
        public ActionResult<IEnumerable<InteractionReadDto>> GetAllInteractions()
        {
            var interactions = _interactionRepo.GetAllInteractions();

            return Ok(_mapper.Map<IEnumerable<Interaction>, IEnumerable<InteractionReadDto>>(interactions));
        }

        // GET /api/interactions/{id}
        [HttpGet("{id}", Name = "GetInteractionById")]
        public async Task<ActionResult<InteractionReadDto>> GetInteractionById(string id)
        {
            var interaction = await _interactionRepo.GetInteractionById(id);

            if (interaction == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Interaction, InteractionReadDto>(interaction));
        }

        // POST /api/interactions
        [HttpPost]
        public async Task<ActionResult<InteractionReadDto>> CreateInteraction(InteractionCreateDto interactionCreateDto)
        {
            var interaction = _mapper.Map<InteractionCreateDto, Interaction>(interactionCreateDto);

            if (interaction.CustomerStatus == CustomerStatus.VIP)
            {
                // send email to John
            }

            _interactionRepo.CreateInteraction(interaction);

            try
            {
                await _interactionRepo.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            var interactionReadDto = _mapper.Map<Interaction, InteractionReadDto>(interaction);

            return CreatedAtRoute(nameof(GetInteractionById), new { Id = interactionReadDto.CallId }, interactionReadDto);
        }
    }
}
