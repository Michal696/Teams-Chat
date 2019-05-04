using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.DAL.Entities
{
    public class TaskAssignment : EntityBase
    {
        [Required]
        public User User { get; set; }
        [Required]
        public Task Task { get; set; }
    }
}
