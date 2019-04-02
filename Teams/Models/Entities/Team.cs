﻿using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Team : EntityBase
    {
        public String Name { get; set; }
        public virtual ICollection<User> Members { get; set; }
    }
}
