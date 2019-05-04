using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class Group : EntityBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual ICollection<GroupUserPermission> GroupUserPermissions { get; set; }

        [Required]
        public Team Team { get; set; }

    }
}
