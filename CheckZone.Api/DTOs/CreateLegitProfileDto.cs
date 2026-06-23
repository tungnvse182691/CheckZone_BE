using System.ComponentModel.DataAnnotations;

namespace CheckZone.Api.DTOs
{
    public class CreateLegitProfileDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Role { get; set; } = string.Empty;

        [Required]
        [Range(0, 100)]
        public int Score { get; set; } = 100;

        [Required]
        [StringLength(512)]
        public string Img { get; set; } = "https://images.domain.com/default-avatar.png";

        [Required]
        public string Desc { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Telegram { get; set; } = "@verified_merchant";

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Insurance { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SuccessTrans { get; set; }

        [Required]
        [StringLength(7)]
        public string JoinDate { get; set; } = string.Empty; // MM/YYYY format

        [Required]
        [StringLength(255)]
        public string BusinessType { get; set; } = string.Empty;
    }
}
