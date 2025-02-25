using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Repositories;
using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure.Persistence
{
    public class ReminderAppDbContext: DbContext, IUnitOfWork
    {
        public ReminderAppDbContext(DbContextOptions<ReminderAppDbContext> options): base(options)
        {
                
        }
        public DbSet<Reminder> Reminders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReminderAppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
