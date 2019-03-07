using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Group
    {
        public String name;
        public String description;
        public virtual ICollection<GroupUserPermission> GroupUserPermissions { get; set; }
        public Team team;

        // @todo later
        void addPermission(User user, Permission permission)
        {

        }

    }
}
