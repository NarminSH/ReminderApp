using MediatR;

using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Factories.Interfaces;
using ReminderApp.Application.Repositories;
using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Reminders.Commands.CreateReminder
{
    public sealed class CreateReminderCommandHandler: IRequestHandler<CreateReminderCommand, Guid>
    {
       
        private readonly IReminderRepository _reminderRepository;
        private readonly IUnitOfWork  _unitOfWork;
        private readonly IReminderScheduler _reminderScheduler; 

        public CreateReminderCommandHandler(IReminderRepository reminderRepository, IUnitOfWork unitOfWork, 
            IReminderScheduler reminderScheduler)
        {
            _reminderRepository = reminderRepository;
            _unitOfWork = unitOfWork;
            _reminderScheduler = reminderScheduler;
        }

        public async Task<Guid> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            var localSendAt = request.sendAt;
            var userTimeZoneOffset = request.TimeZoneOffset;  // Offset in minutes (handled by front in js)
            var utcSendAt = localSendAt.AddMinutes(-userTimeZoneOffset);  // Convert to UTC
            var reminder = new Reminder(Guid.NewGuid(), request.to, request.content, utcSendAt, request.methodType);
            await _reminderRepository.AddAsync(reminder);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _reminderScheduler.ScheduleReminderAsync(request.to, request.content, utcSendAt, request.methodType.ToString());

            return reminder.Id;
        }
    }
}
