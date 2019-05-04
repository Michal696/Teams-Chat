using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.DAL.Entities
{
    public class TaskAssignment : EntityBase
    {
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Task Task { get; set; }
    }
}
