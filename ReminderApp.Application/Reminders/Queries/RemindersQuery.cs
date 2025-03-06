using AutoMapper;
using MediatR;
using ReminderApp.Application.Reminders.Dtos;
using ReminderApp.Application.Repositories;
using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Reminders.Queries
{
    public record RemindersQuery : IRequest<IEnumerable<ReminderDto>>;

    public class RemindersQueryHandler : IRequestHandler<RemindersQuery, IEnumerable<ReminderDto>>
    {
        private readonly IReminderRepository _reminderRepository;
        private readonly IMapper _mapper;

        public RemindersQueryHandler(IReminderRepository repository, IMapper mapper)
        {
           _reminderRepository = repository;
           _mapper = mapper;
        }

        public async Task<IEnumerable<ReminderDto>> Handle(RemindersQuery request, CancellationToken cancellationToken)
        {
            var reminders = await _reminderRepository.GetAllAsync();
            var reminderDtos = _mapper.Map<IEnumerable<ReminderDto>>(reminders);
            return reminderDtos;
        }

    }
}
