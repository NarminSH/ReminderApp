using ReminderApp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Services
{
    public class TelegramService : ITelegramService
    {
       

        public TelegramService()
        {
           
        }


        public Task SendReminderAsync(string to, string content)
        {
            throw new NotImplementedException();
        }
    }
}
