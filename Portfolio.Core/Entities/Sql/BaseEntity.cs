﻿using System.ComponentModel.DataAnnotations;

namespace Portfolio.Core.Entities.Sql
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DisabledAt { get; set; } = null;
    }
}
