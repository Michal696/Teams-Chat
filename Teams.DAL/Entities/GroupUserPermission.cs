using System;

namespace Teams.DAL.Entities
{
    public class GroupUserPermission : EntityBase
    {
        public Group Group { get; set; }

        public User Member { get; set; }
        public Permission Permit { get; set; }
    }

    public enum Permission
    {
        READ = 0,
        WRITE = 1,
        MANAGE = 2,
    }
}
