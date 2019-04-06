using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class GroupModel : ModelBase
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual ICollection<GroupUserPermissionModel> GroupUserPermissions { get; set; }
        public TeamModel Team { get; set; }
    }
}
