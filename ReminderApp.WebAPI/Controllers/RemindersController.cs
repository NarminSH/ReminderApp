using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReminderApp.Application.Reminders.Commands.CreateReminder;

namespace ReminderApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemindersController : ApiBaseController
    {
        [HttpPost]
        public async Task<Guid> Post([FromBody] CreateReminderCommand value, CancellationToken cancellationToken)
        {
            var res = await Mediator.Send(value, cancellationToken);
            return res;
        }
    }
}
