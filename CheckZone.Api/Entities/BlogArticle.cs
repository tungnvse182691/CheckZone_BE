using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckZone.Api.Entities
{
    public class BlogArticle
    {
        [Key]
        [Required]
        [MaxLength(20)]
        [Column("id")]
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("category")]
        public string Category { get; set; } = "Cảnh báo phổ thông";

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(255)]
        [Column("slug")]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("status")]
        public string Status { get; set; } = "Đã đăng";

        [Column("content", TypeName = "text")]
        public string? Content { get; set; }
    }
}
