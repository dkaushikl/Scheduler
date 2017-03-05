﻿using System.Collections.Generic;
using AutoMapper;
using Scheduler.Model.Entities;

namespace Scheduler.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ScheduleViewModel, Schedule>()
                .ForMember(s => s.Creator, map => map.UseValue(null))
                .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}