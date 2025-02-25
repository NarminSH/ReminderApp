using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReminderApp.Application.Reminders.Commands.CreateReminder
{

    public class CreateReminderCommandValidator : AbstractValidator<CreateReminderCommand>
    {

        public CreateReminderCommandValidator()
        {
            
            RuleFor(r => r.to)
                .NotEmpty().WithMessage("Please provide email address or telegram ID")
                .Must(BeValidEmailOrTelegramId).WithMessage("Please provide a valid email address or telegram ID");

            RuleFor(r => r.content)
                .NotEmpty().WithMessage("Please write content").MinimumLength(4).WithMessage("Minimum is 4 ");

            RuleFor(r => r.sendAt)
                .NotEmpty().WithMessage("Send time is required")
                .GreaterThan(DateTime.Now).WithMessage("Please enter a valid date");

            RuleFor(r => r.methodType)
                .IsInEnum().WithMessage("Method type must be either 'Email' or 'Telegram'");
        }
        private bool BeValidEmailOrTelegramId(string to)
        {
            if (string.IsNullOrEmpty(to))
                return false;

            if (IsValidEmail(to))
                return IsValidEmail(to);

            bool isValidTelegramId = Regex.IsMatch(to, @"^@[a-zA-Z0-9_]+$");
            return isValidTelegramId;
        }
        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }

    }
}
