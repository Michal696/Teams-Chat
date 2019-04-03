using System;
using System.Collections.Generic;

namespace Teams.DAL.Entities
{
    public class Task : EntityBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public User Member { get; set; } 
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public virtual ICollection<TaskStateChange> TaskStateChanges { get; set; }

        public TaskState State { get; set; }
        public Group Group { get; set; }


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
