﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Teams.DAL.Entities.Enums;

namespace Teams.DAL.Entities
{
    public class Task : EntityBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        [Required]
        public virtual User User { get; set; } 
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public virtual ICollection<TaskStateChange> TaskStateChanges { get; set; }
        
        public TaskState State { get; set; }
        [Required]
        public virtual Group Group { get; set; }
    }
}
