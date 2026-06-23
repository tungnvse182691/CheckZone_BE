using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckZone.Api.Entities
{
    public class SystemConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public int Id { get; set; } = 1;

        [Required]
        [Column("require_evidence")]
        public bool RequireEvidence { get; set; } = true;

        [Required]
        [Column("auto_approve")]
        public bool AutoApprove { get; set; } = false;

        [Required]
        [Column("min_insurance", TypeName = "decimal(15, 2)")]
        public decimal MinInsurance { get; set; } = 10000000.00m;

        [Required]
        [MaxLength(255)]
        [Column("admin_name")]
        public string AdminName { get; set; } = "Ban điều hành Check Zone";

        [Required]
        [MaxLength(255)]
        [Column("admin_email")]
        public string AdminEmail { get; set; } = "support@checkzone.vn";

        [MaxLength(255)]
        [Column("telegram_bot_token")]
        public string? TelegramBotToken { get; set; }
    }
}
