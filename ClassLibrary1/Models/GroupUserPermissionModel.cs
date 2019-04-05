using System;
using Teams.BL.Models;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class GroupUserPermissionModel : ModelBase
    {
        public GroupModel Group { get; set; }

        public UserModel Member { get; set; }
        public Permission Permit { get; set; }
    }
}
