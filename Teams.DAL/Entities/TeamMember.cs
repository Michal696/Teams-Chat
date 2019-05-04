using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teams.DAL.Entities
{
    public class TeamMember : EntityBase
    {
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Team Team { get; set; }
    }
}
