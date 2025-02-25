using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReminderApp.Application.Abstractions;

namespace ReminderApp.Application.Factories.Interfaces
{
    public interface IMessageServiceFactory
    {
        IMessageService GetMessageService(string methodType);
    }
}
