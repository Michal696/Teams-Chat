using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class TaskAssignmentModel : ModelBase
    {
        public UserModel Member { get; set; }
        public TaskModel Task { get; set; }
    }
}
