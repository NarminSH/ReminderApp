using AutoMapper;
using ReminderApp.Application.Repositories;
using ReminderApp.Domain.Common;
using ReminderApp.Domain.Entities;
using ReminderApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Repositories.Implementations
{
    public class ReminderRepository: GenericRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(ReminderAppDbContext dbContext):base(dbContext) { }
    }
}
