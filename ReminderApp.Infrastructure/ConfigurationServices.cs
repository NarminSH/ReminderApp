using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Infrastructure.Persistence;
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
            return serviceCollection;
        }
    }
}
