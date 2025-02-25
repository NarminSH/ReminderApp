using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReminderApp.WebAPI.Controllers
{
    
    [ApiController]
    public abstract partial class ApiBaseController : ControllerBase
    {
        private ISender _mediator = null;
        public ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
