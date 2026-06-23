using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckZone.Api.Entities
{
    public class PolicyArticle
    {
        [Key]
        [Required]
        [MaxLength(20)]
        [Column("id")]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Column("last_updated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("active")]
        public bool Active { get; set; } = true;

        [Column("content", TypeName = "text")]
        public string? Content { get; set; }
    }
}
