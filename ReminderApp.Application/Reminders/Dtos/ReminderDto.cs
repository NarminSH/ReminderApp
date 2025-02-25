using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Reminders.Dtos
{
    public class ReminderDto
    {
        public Guid Id { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public ReminderMethodType MethodType { get; set; }
    }
}
