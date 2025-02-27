using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Repositories;
using ReminderApp.Infrastructure.Persistence;
using ReminderApp.Infrastructure.Repositories.Implementations;
using ReminderApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Infrastructure
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ReminderAppDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                       builder => builder.MigrationsAssembly(typeof(ReminderAppDbContext).Assembly.FullName)));
           
            serviceCollection.AddHangfire(config =>
                config.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));

           
            serviceCollection.AddHangfireServer();
            serviceCollection.AddScoped<IReminderScheduler, ReminderScheduler>();


            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IReminderRepository, ReminderRepository>();
            serviceCollection.AddSingleton<IMessageService, EmailService>();
            serviceCollection.AddSingleton<IEmailService, EmailService>();
            serviceCollection.AddSingleton<IMessageService, TelegramService>();
            serviceCollection.AddSingleton<ITelegramService, TelegramService>();
            
            return serviceCollection;
        }
    }
}
