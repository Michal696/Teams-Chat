using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class TeamMember : EntityBase
    {
        public User User { get; set; }
        public Team Team { get; set; }
    }
}
