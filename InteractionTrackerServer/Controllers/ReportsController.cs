using AutoMapper;
using InteractionTrackerServer.Data;
using InteractionTrackerServer.Dtos.ReadDtos;
using InteractionTrackerServer.Enums;
using InteractionTrackerServer.Models;
using InteractionTrackerServer.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InteractionTrackerServer.Controllers
{
    [ApiController]
    [Route("/api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly IInteractionRepo _interactionRepo;
        private readonly IMapper _mapper;

        public ReportsController(IInteractionRepo interactionRepo, IMapper mapper)
        {
            _interactionRepo = interactionRepo;
            _mapper = mapper;
        }

        // GET /api/reports/daily
        [HttpGet("daily")]
        public ActionResult<Report> GetDailyReport()
        {
            var interactionsToday = _interactionRepo.GetAllInteractions().Where(i => i.Timestamp >= DateTime.Today && i.Timestamp < DateTime.Today.AddDays(1));
            var todaysReport = ReportGenerator.GenerateReport(interactionsToday);

            return Ok(_mapper.Map<Report, ReportReadDto>(todaysReport));
        }
    }
}
