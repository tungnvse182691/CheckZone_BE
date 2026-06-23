using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckZone.Api.Entities
{
    public class LegitProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("role")]
        public string Role { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        [Column("score")]
        public int Score { get; set; } = 100;

        [Required]
        [MaxLength(512)]
        [Column("img")]
        public string Img { get; set; } = "https://images.domain.com/default-avatar.png";

        [Required]
        [Column("desc", TypeName = "text")]
        public string Desc { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        [Column("phone")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("telegram")]
        public string Telegram { get; set; } = "@verified_merchant";

        [Required]
        [Column("insurance", TypeName = "decimal(15, 2)")]
        public decimal Insurance { get; set; } = 0m;

        [Required]
        [Column("success_trans")]
        public int SuccessTrans { get; set; } = 0;

        [Required]
        [MaxLength(7)]
        [Column("join_date")]
        public string JoinDate { get; set; } = string.Empty; // MM/YYYY format

        [Required]
        [MaxLength(255)]
        [Column("business_type")]
        public string BusinessType { get; set; } = string.Empty;
    }
}
