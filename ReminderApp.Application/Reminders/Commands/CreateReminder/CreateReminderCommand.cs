using MediatR;
using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ReminderApp.Application.Reminders.Commands.CreateReminder
{
    public record CreateReminderCommand(string to, string content, DateTime sendAt,
            ReminderMethodType methodType, int TimeZoneOffset ): IRequest<Guid>;


}
