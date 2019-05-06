using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teams.BL.Messages
{
    public class TeamUserRemoveMessage : IMessage
    {
        public Guid Id { get; set; }
    }
}
