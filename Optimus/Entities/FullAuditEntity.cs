﻿using System.ComponentModel.DataAnnotations;

namespace Optimus.Entities
{
    public class FullAuditEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now; 
        public DateTime? UpdatedOn { get; set; }

    }
}
