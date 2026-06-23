using System;
using System.Collections.Generic;

namespace CheckZone.Api.DTOs
{
    public class ScamReportDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Victim { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string? Facebook { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; }
        public int Category { get; set; }
    }
}
