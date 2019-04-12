using System;

namespace Teams.DAL.Entities
{
    public class Media : EntityBase
    {
        public virtual Message Parent { get; set; }
        public String Data { get; set; }
    }
}
