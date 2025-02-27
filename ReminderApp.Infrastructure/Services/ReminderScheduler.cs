using Hangfire;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Services
{
    public class ReminderScheduler : IReminderScheduler
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IMessageServiceFactory _messageServiceFactory;

        public ReminderScheduler(IBackgroundJobClient backgroundJobClient, IMessageServiceFactory messageServiceFactory)
        {
            _backgroundJobClient = backgroundJobClient;
            _messageServiceFactory = messageServiceFactory;
        }

        public Task ScheduleReminderAsync(string to, string content, DateTime sendAt, string methodType)
        {
            var delay = sendAt - DateTime.UtcNow;

            if (delay.TotalMilliseconds > 0)
            {
                _backgroundJobClient.Schedule(
                    () => SendReminder(to, content, methodType),
                    delay  
                );
            }

            return Task.CompletedTask;
        }

        public void SendReminder(string to, string content, string methodType)
        {
            var messageSender = _messageServiceFactory.GetMessageService(methodType);
            messageSender.SendReminderAsync(to, content).GetAwaiter().GetResult();
        }
    }
}
