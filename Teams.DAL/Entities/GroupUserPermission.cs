using System;
using Teams.DAL.Entities.Enums;

namespace Teams.DAL.Entities
{
    public class GroupUserPermission : EntityBase
    {
	[Required]
        public virtual Group Group { get; set; }

	[Required]
        public virtual User User { get; set; }
        
        public Permission Permit { get; set; }
    }
}
