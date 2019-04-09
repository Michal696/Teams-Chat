using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.DAL.Entities
{
    public class TaskAssignment : EntityBase
    {
        public User User { get; set; }
        public Task Task { get; set; }
    }
}
