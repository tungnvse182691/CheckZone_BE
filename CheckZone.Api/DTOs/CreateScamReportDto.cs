using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckZone.Api.DTOs
{
    public class CreateScamReportDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; } = string.Empty;

        [Required]
        [MinLength(10)]
        public string Desc { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100)]
        public string Victim { get; set; } = "Ẩn danh";

        [Required]
        public List<string> Tags { get; set; } = new List<string>();

        [StringLength(512)]
        public string? Facebook { get; set; }

        [Required]
        public List<string> Images { get; set; } = new List<string>();

        [Required]
        [Range(0, 1)]
        public int Category { get; set; }

        [Required]
        public string CaptchaToken { get; set; } = string.Empty;
    }
}
