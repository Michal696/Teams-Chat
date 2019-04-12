using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class TeamMember : EntityBase
    {
        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}
