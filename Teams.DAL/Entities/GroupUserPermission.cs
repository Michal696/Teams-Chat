using System;
using Teams.DAL.Entities.Enums;

namespace Teams.DAL.Entities
{
    public class GroupUserPermission : EntityBase
    {
        public virtual Group Group { get; set; }

        public virtual User User { get; set; }
        public Permission Permit { get; set; }
    }
}
