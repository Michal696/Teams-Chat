using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Team : BaseEntity
    {
        public String name;
        public virtual ICollection<User> Members { get; set; }
    }

    public class TeamMember : BaseEntity
    {
        public User user;
        public Team team;
    }
}
