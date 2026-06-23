using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckZone.Api.Entities
{
    public enum ScamCategory
    {
        FinancialScam = 0,
        BehavioralWarning = 1
    }

    public class ScamReport
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

        [MaxLength(20)]
        [Column("phone")]
        public string? Phone { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("bank_name")]
        public string BankName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [Column("account_number")]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [Column("desc", TypeName = "text")]
        public string Desc { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("type")]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Column("amount", TypeName = "decimal(15, 2)")]
        public decimal Amount { get; set; } = 0m;

        [Required]
        [MaxLength(50)]
        [Column("status")]
        public string Status { get; set; } = "Đang chờ duyệt";

        [Required]
        [MaxLength(100)]
        [Column("victim")]
        public string Victim { get; set; } = "Ẩn danh";

        [Required]
        [Column("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [MaxLength(512)]
        [Column("facebook")]
        public string? Facebook { get; set; }

        [Required]
        [Column("images")]
        public List<string> Images { get; set; } = new List<string>();

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("category")]
        public ScamCategory Category { get; set; } = ScamCategory.FinancialScam;
    }
}
