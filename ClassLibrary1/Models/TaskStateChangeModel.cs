using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TaskStateChangeModel : ModelBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public UserModel Member { get; set; }
        public virtual ICollection<TaskAssignmentModel> TaskAssignments { get; set; }
        public TaskState State { get; set; }
        public GroupModel Group { get; set; }
    }
}
