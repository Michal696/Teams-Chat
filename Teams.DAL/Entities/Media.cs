using System;

namespace Teams.DAL.Entities
{
    public class Media : EntityBase
    {

        public Message Parent { get; set; }
        public byte[] Data { get; set; }

    }
}
