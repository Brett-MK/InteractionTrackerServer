using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalkDeskInterviewApp.Data;
using TalkDeskInterviewApp.Dtos;
using TalkDeskInterviewApp.Models;

namespace TalkDeskInterviewApp.Controllers
{
    [ApiController]
    [Route("/api/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _commandRepo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo commandRepo, IMapper mapper)
        {
            _commandRepo = commandRepo;
            _mapper = mapper;
        }

        // GET /api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands([FromQuery]RequestFilterDto filter)
        {
            var commands = _commandRepo.GetAllCommands();

            if (filter != null && filter.PageNumber != 0 && filter.PageSize != 0)
            {
                commands = commands.Skip(filter.PageNumber * filter.PageSize).Take(filter.PageSize);
            }
            if (filter != null && filter.PlatformFilter != null)
            {
                commands = commands.Where(c => c.Platform.Contains(filter.PlatformFilter));
            }
            
            return Ok(_mapper.Map<IEnumerable<Command>, IEnumerable<CommandReadDto>>(commands));
        }

        // GET /api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandById(int id)
        {
            var command = await _commandRepo.GetCommandById(id);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Command, CommandReadDto>(command));
        }

        // POST /api/commands
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var command = _mapper.Map<CommandCreateDto, Command>(commandCreateDto);

            _commandRepo.CreateCommand(command);
            await _commandRepo.SaveChanges();

            var commandReadDto = _mapper.Map<Command, CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        // PUT /api/commands/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromRepo = await _commandRepo.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandFromRepo);

            _commandRepo.UpdateCommand(commandFromRepo);
            await _commandRepo.SaveChanges();

            return NoContent();
        }

        // PATCH /api/commands/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartiallyUpdateCommand(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandFromRepo = await _commandRepo.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<Command, CommandUpdateDto>(commandFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandFromRepo);

            _commandRepo.UpdateCommand(commandFromRepo);
            await _commandRepo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var commandFromRepo = await _commandRepo.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _commandRepo.DeleteCommand(commandFromRepo);
            await _commandRepo.SaveChanges();

            return NoContent();
        }
    }
}
