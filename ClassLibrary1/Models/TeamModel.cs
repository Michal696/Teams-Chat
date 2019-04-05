using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TeamModel : ModelBase
    {
        public String Name { get; set; }
        public virtual ICollection<UserModel> Members { get; set; }
    }
}
