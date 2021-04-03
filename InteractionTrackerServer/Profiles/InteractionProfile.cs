using AutoMapper;
using InteractionTrackerServer.Dtos.CreateDtos;
using InteractionTrackerServer.Dtos.ReadDtos;
using InteractionTrackerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Profiles
{
    public class InteractionProfile : Profile
    {
        public InteractionProfile()
        {
            // Source -> Target
            CreateMap<InteractionCreateDto, Interaction>();
            CreateMap<AgentDataCreateDto, AgentData>();
            CreateMap<CallDataCreateDto, CallData>();
            CreateMap<TimeWithUnitCreateDto, TimeWithUnit>();

            CreateMap<Interaction, InteractionReadDto>();
            CreateMap<AgentData, AgentDataReadDto>();
            CreateMap<CallData, CallDataReadDto>();
            CreateMap<TimeWithUnit, TimeWithUnitReadDto>();
        }
    }
}
