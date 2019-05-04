using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class TeamMember : EntityBase
    {
        [Required]
        public User User { get; set; }
        [Required]
        public Team Team { get; set; }
    }
}
