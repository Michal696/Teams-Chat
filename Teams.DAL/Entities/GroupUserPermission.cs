using System;
using Teams.DAL.Entities.Enums;

namespace Teams.DAL.Entities
{
    public class GroupUserPermission : EntityBase
    {
        public Group Group { get; set; }

        public User Member { get; set; }
        public Permission Permit { get; set; }
    }
}
