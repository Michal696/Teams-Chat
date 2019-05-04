using System;
using Teams.DAL.Entities.Enums;

namespace Teams.DAL.Entities
{
    public class GroupUserPermission : EntityBase
    {
	[Required]
        public Group Group { get; set; }

	[Required]
        public User Member { get; set; }
        
        public Permission Permit { get; set; }
    }
}
