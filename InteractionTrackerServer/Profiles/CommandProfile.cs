using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractionTrackerServer.Dtos;
using InteractionTrackerServer.Models;

namespace InteractionTrackerServer.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source => target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandReadDto, Command>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}
