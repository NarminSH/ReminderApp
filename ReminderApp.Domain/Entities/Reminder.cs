using ReminderApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Domain.Entities
{
    public sealed class Reminder: BaseEntity
    {
        public Reminder(Guid id, string to,string content, DateTimeOffset sendAt,
            ReminderMethodType methodType): base(id)
        {
            To = to;
            Content = content;
            SendAt = sendAt;
            MethodType = methodType;
        }

            public string To { get; set; }
            public ReminderMethodType MethodType { get; set; }
            public string Content { get; set; }
            public DateTimeOffset SendAt { get; set; }
        
    }
}
