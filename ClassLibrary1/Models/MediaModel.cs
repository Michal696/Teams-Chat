using System;
using System.Collections.Generic;
using Teams.BL.Models.Base;

namespace Teams.BL.Models
{
    public class MediaModel : ModelBase
    {
        public MessageModel Parent { get; set; }
        public String Data { get; set; }

    }
}
