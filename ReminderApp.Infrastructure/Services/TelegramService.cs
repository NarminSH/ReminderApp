using Microsoft.Extensions.Configuration;
using ReminderApp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ReminderApp.Infrastructure.Services
{
    public class TelegramService : ITelegramService
    {

        private readonly TelegramBotClient _botClient;
        public TelegramService(IConfiguration configuration)
        {
            var botToken = configuration["TELEGRAM_BOT_TOKEN"];

            if (string.IsNullOrEmpty(botToken))
            {
                throw new Exception("Bot token is missing! Set the TELEGRAM_BOT_TOKEN environment variable.");
            }
            _botClient = new TelegramBotClient(botToken);
        }

        public async Task SendReminderAsync(string to, string content)
        {
            await _botClient.SendTextMessageAsync(chatId: to, text: content);
        }
    }
}
