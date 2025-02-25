using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Factories.Implementations
{
    public class MessageServiceFactory : IMessageServiceFactory
    {
        private readonly IEmailService _emailService;
        private readonly ITelegramService _telegramService;

        public MessageServiceFactory(IEmailService emailService, ITelegramService telegramService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _telegramService = telegramService ?? throw new ArgumentNullException(nameof(telegramService));
        }

        public IMessageService GetMessageService(string methodType)
        {
            if (methodType == "Email")
                return _emailService;

            if (methodType == "Telegram")
                return _telegramService;

            throw new ArgumentException("Unsupported method type", nameof(methodType));
        }
    }
}
