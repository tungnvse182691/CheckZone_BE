namespace CheckZone.Api.DTOs
{
    public class LegitProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int Score { get; set; }
        public string Img { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Telegram { get; set; } = string.Empty;
        public decimal Insurance { get; set; }
        public int SuccessTrans { get; set; }
        public string JoinDate { get; set; } = string.Empty;
        public string BusinessType { get; set; } = string.Empty;
        public string Tier { get; set; } = string.Empty; // badge like "Hạng Kim Cương"
    }
}
