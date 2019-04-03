using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class User : EntityBase
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public String Image { get; set; } 
        public String Email { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual ICollection<GroupUserPermission> GroupUserPermissions { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Media> MediaEntities { get; set; }
        public virtual ICollection<TaskAssignment> Tasks { get; set; }

    }
}
