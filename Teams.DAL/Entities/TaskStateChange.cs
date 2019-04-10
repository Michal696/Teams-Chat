using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.DAL.Entities.Enums;

namespace Teams.DAL.Entities
{
    public class TaskStateChange : EntityBase
    {
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public User User { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public TaskState State { get; set; }
        public Group Group { get; set; }
        public Task Task { get; set; }
    }
}
