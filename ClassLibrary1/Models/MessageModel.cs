using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class MessageModel : ModelBase
    {

        public String Title { get; set; }
        public DateTime TimeStamp { get; set; }
        public String Text { get; set; }
        public UserModel User { get; set; }
        public MessageModel Parent { get; set; }
        public GroupModel Group { get; set; }
        public int ChildCount { get; set; }
    }
}
