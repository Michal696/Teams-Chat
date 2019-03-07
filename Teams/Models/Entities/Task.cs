using System;
using System.Collections.Generic;

namespace Teams.Models.Entities
{
    public class Task : BaseEntity
    {
        public DateTime dateTime;
        public String text;
        public User user;
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public virtual ICollection<TaskStateChange> TaskStateChanges { get; set; }

        public TaskState state;
        public Group group;


    }
    
    public class TaskAssignment : BaseEntity
    {
        public User user;
        public Task task;
    }

    public class TaskStateChange : BaseEntity
    {
        public DateTime dateTime;
        public String text;
        public User user;
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public TaskState state;
        public Group group;
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
