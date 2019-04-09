
using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class UserModel : ModelBase
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public String Image { get; set; } 
        public String Email { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
