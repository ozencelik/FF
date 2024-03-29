﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FF.Data.Entities.Base
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Used as primary key for all entities
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Determine the entity is deleted
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Created date of an entity
        /// </summary>
        public DateTime Created { get; protected set; } = DateTime.Now;

        /// <summary>
        /// Updated date of an entity
        /// </summary>
        public DateTime Updated { get; set; }
    }
}
