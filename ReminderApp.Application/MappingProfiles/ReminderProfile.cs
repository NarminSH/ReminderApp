using AutoMapper;
using ReminderApp.Application.Reminders.Dtos;
using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.MappingProfiles
{
    public class ReminderProfile:Profile
    {
        public ReminderProfile()
        {
             CreateMap<ReminderDto, Reminder>().ReverseMap();
        }
    }
}
