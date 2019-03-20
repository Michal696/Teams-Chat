using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Team : BaseEntity
    {
        public String Name { get; set; }
        public virtual ICollection<User> Members { get; set; }
    }

    public class TeamMember : BaseEntity
    {
        public User Member { get; set; }
        public Team Team_ { get; set; }
    }
}
