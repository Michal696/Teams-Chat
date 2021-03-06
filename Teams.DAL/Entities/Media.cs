﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Teams.DAL.Entities
{
    public class Media : EntityBase
    {
        [Required]
        public virtual Message Parent { get; set; }
        public String Data { get; set; }
    }
}
