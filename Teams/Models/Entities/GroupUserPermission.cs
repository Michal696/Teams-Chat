using System;

namespace Teams.Models.Entities
{
    public class GroupUserPermission
    {
        public Group group;
        public User user;
        public Permission permission;
    }

    public enum Permission
    {
        read = 0,
        write = 1,
        manage = 2,
    }
}
