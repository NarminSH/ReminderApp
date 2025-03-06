using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Reminders.Commands.CreateReminder;
using ReminderApp.Application.Reminders.Dtos;
using ReminderApp.Application.Reminders.Queries;

namespace ReminderApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ApiBaseController
    {
        [HttpGet]
        public async Task<IEnumerable<ReminderDto>> GetReminders()
        {
            return await Mediator.Send(new RemindersQuery()); 
        }

        [HttpPost]
        public async Task<Guid> Post([FromBody] CreateReminderCommand value, CancellationToken cancellationToken)
        {
            var res = await Mediator.Send(value, cancellationToken);
            return res;
        }
    }
}
