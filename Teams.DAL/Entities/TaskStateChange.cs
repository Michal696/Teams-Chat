using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual User User { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public TaskState State { get; set; }
        [Required]
        public virtual Group Group { get; set; }
        [Required]
        public virtual Task Task { get; set; }
    }
}
