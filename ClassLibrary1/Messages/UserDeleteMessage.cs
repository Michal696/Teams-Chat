﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.BL.Messages
{
    public class UserDeleteMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
