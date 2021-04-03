using AutoMapper;
using InteractionTrackerServer.Dtos.ReadDtos;
using InteractionTrackerServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionTrackerServer.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            // Source -> Target
            CreateMap<Report, ReportReadDto>();
            CreateMap<TrafficByCustomerStatus, TrafficByCustomerStatusReadDto>();
        }
    }
}
