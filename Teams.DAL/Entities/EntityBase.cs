using System;
using Teams.DAL.Interfaces;

namespace Teams.DAL.Entities
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
