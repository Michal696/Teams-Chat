using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TaskModel : ModelBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public UserModel Member { get; set; } 
        public virtual ICollection<TaskAssignmentModel> TaskAssignments { get; set; }
        public virtual ICollection<TaskStateChangeModel> TaskStateChanges { get; set; }

        public TaskState State { get; set; }
        public GroupModel Group { get; set; }


    }

    public enum TaskState
    {
        NEW = 0,
        WORKING_ON = 1,
        TO_BE_TESTED = 2,
        TESTED = 3,
        DEPLOYED = 4,
    
    }
}
