using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Enums;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TaskStateChangeModel : ModelBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public TaskState State { get; set; }
    }
}
