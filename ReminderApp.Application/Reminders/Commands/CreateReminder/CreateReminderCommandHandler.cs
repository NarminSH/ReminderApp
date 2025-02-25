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
        private readonly IMessageServiceFactory _messageServiceFactory;
        private readonly IReminderRepository _reminderRepository;
        private readonly IUnitOfWork  _unitOfWork;


        public CreateReminderCommandHandler(IReminderRepository reminderRepository, IUnitOfWork unitOfWork, IMessageServiceFactory messageServiceFactory)
        {
            _reminderRepository = reminderRepository;
            _unitOfWork = unitOfWork;
            _messageServiceFactory = messageServiceFactory;
        }

        public async Task<Guid> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {

            var reminder = new Reminder(Guid.NewGuid(), request.to, request.content, request.sendAt, request.methodType);
            await _reminderRepository.AddAsync(reminder);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            IMessageService messageSender = _messageServiceFactory.GetMessageService(request.methodType.ToString());
            await messageSender.SendReminderAsync(request.to, request.content);
            return reminder.Id;
        }
    }
}
