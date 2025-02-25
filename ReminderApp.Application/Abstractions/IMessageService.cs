using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Abstractions
{
    public interface IMessageService
    {
        Task SendReminderAsync(string to, string content);
    }
                           
}
