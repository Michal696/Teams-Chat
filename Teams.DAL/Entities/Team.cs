using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class Team : EntityBase
    {
        public String Name { get; set; }
        public virtual ICollection<User> Members { get; set; }
    }
}
