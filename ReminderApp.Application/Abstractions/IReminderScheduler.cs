using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Abstractions
{
    public interface IReminderScheduler
    {
        Task ScheduleReminderAsync(string to, string content, DateTime sendAt, string methodType);
    }
}


