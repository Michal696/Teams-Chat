using System;

namespace Teams.Models.Entities
{
    public class GroupUserPermission
    {
        public Group Group_ { get; set; }

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
