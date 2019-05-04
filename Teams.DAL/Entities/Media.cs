using System;

namespace Teams.DAL.Entities
{
    public class Media : EntityBase
    {
        [Required]
        public Message Parent { get; set; }
        public String Data { get; set; }
    }
}
