using System;
using Teams.BL.Models;
using Teams.BL.Models.Base;
using Teams.DAL.Entities.Enums;

namespace Teams.BL.Models
{
    public class GroupUserPermissionModel : ModelBase
    {
        public Permission Permit { get; set; }
    }
}
