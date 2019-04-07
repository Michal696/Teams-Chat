using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.BL.Enums
{
    public enum TaskState
    {
        NEW = 0,
        WORKING_ON = 1,
        TO_BE_TESTED = 2,
        TESTED = 3,
        DEPLOYED = 4,

    }
}
