using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class User : BaseEntity
    {
        public String name;
        public String password;
        public String image;
        public String email;
        public DateTime last_login;
        public virtual ICollection<GroupUserPermission> GrouUserPermissions { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Media> MediaEntities { get; set; }
        public virtual ICollection<TaskAssignment> Tasks { get; set; }

    }
}
