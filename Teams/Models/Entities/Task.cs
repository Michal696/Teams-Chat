using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Task : BaseEntity
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public User Member { get; set; } 
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public virtual ICollection<TaskStateChange> TaskStateChanges { get; set; }

        public TaskStats State { get; set; }
        public Group Group_ { get; set; }


    }
    
    public class TaskAssignment : BaseEntity
    {
        public User Member { get; set; }
        public Task Task_ { get; set; }
    }

    public class TaskStateChange : BaseEntity
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public User Member { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public TaskState State { get; set; }
        public Group Group_ { get; set; }
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
