﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp.Domain.Common
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id)=> Id = id;
        protected BaseEntity() { }

        public Guid Id { get; protected set; }
    }
}
