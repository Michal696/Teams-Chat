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
        [Required]
        public User User { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public TaskState State { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]
        public Task Task { get; set; }
    }
}
