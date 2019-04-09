using System;
using System.Collections.Generic;
using Teams.BL.Enums;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TaskModel : ModelBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public UserModel User { get; set; }
        public TaskState State { get; set; }
        public GroupModel Group { get; set; }

    }
}
