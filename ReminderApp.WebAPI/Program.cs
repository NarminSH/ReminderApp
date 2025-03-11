using FluentValidation.AspNetCore;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Application;
using ReminderApp.Infrastructure;
using ReminderApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080"); // Ensure the correct port is used
builder.WebHost.UseUrls("http://0.0.0.0:8081");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddFluentValidationAutoValidation(configuration => configuration.DisableDataAnnotationsValidation = false)
    .AddFluentValidationClientsideAdapters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();
// Apply migrations at runtime
app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseHangfireDashboard("/hangfire");
app.MapControllers();

app.Run();
