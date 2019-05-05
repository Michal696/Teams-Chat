using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teams.DAL.Entities
{
    public class Group : EntityBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual ICollection<GroupUserPermission> GroupUserPermissions { get; set; }

        [Required]
        public virtual Team Team { get; set; }

    }
}
