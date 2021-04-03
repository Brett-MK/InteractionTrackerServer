using AutoMapper;
using InteractionTrackerServer.Data;
using InteractionTrackerServer.Dtos.CreateDtos;
using InteractionTrackerServer.Dtos.ReadDtos;
using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Hubs;
using InteractionTrackerServer.Models;
using InteractionTrackerServer.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<InteractionHub> _hub;

        public InteractionsController(IInteractionRepo interactionRepo, IMapper mapper, IHubContext<InteractionHub> hub)
        {
            _interactionRepo = interactionRepo;
            _mapper = mapper;
            _hub = hub;
        }

        // GET /api/interactions
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<InteractionReadDto>> GetAllInteractions()
        {
            var interactions = _interactionRepo.GetAllInteractions().OrderByDescending(i => i.Timestamp);

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

                var allInteractions = _interactionRepo.GetAllInteractions().OrderByDescending(i => i.Timestamp);
                var dailyReport = ReportGenerator.GenerateReport(allInteractions.Where(i => i.Timestamp >= DateTime.Today && i.Timestamp < DateTime.Today.AddDays(1)));
                await _hub.Clients.All.SendAsync("InteractionsAdded", _mapper.Map<IEnumerable<Interaction>, IEnumerable<InteractionReadDto>>(allInteractions));
                await _hub.Clients.All.SendAsync("DailyReportUpdated", _mapper.Map<Report, ReportReadDto>(dailyReport));
            }
            catch(Exception e)
            {
                return BadRequest();
            }

            var interactionReadDto = _mapper.Map<Interaction, InteractionReadDto>(interaction);

            return CreatedAtRoute(nameof(GetInteractionById), new { Id = interactionReadDto.CallId }, interactionReadDto);
        }
    }
}
