using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Domain.Exceptions
{
    public sealed class ReminderNotFoundException: Exception
    {
        public ReminderNotFoundException(Guid reminderId): base($"The reminder with the identifier {reminderId} was not found")
        {
                
        }
    }
}
