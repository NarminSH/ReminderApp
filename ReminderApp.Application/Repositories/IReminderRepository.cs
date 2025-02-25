using ReminderApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Application.Repositories
{
    public  interface IReminderRepository: IGenericRepository<Reminder>
    {
    }
    
}
