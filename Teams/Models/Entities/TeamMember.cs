using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class TeamMember : EntityBase
    {
        public User Member { get; set; }
        public Team Team_ { get; set; }
    }
}
