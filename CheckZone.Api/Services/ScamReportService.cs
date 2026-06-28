using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheckZone.Api.Data;
using CheckZone.Api.DTOs;
using CheckZone.Api.Entities;

namespace CheckZone.Api.Services
{
    public class ScamReportService : IScamReportService
    {
        private readonly AppDbContext _context;

        public ScamReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScamReportDto>> GetAllApprovedAsync()
        {
            var reports = await _context.ScamReports
                .Where(x => x.Status == "Đã phê duyệt" && x.Category == ScamCategory.FinancialScam)
                .ToListAsync();

            return reports.Select(MapToDto);
        }

        public async Task<IEnumerable<ScamReportDto>> GetWarningsAsync()
        {
            var reports = await _context.ScamReports
                .Where(x => x.Status == "Đã phê duyệt" && x.Category == ScamCategory.BehavioralWarning)
                .ToListAsync();

            return reports.Select(MapToDto);
        }

        public async Task<ScamReportDto?> GetByIdAsync(string id)
        {
            var report = await _context.ScamReports.FindAsync(id);
            return report == null ? null : MapToDto(report);
        }

        public async Task<ScamReportDto> SubmitReportAsync(CreateScamReportDto dto)
        {
            var random = new Random();
            string generatedId;
            bool exists;
            do
            {
                generatedId = $"SCM-{random.Next(1000, 9999)}";
                exists = await _context.ScamReports.AnyAsync(x => x.Id == generatedId);
            } while (exists);

            var report = new ScamReport
            {
                Id = generatedId,
                Name = dto.Name,
                Phone = dto.Phone,
                BankName = dto.BankName,
                AccountNumber = dto.AccountNumber,
                Desc = dto.Desc,
                Type = dto.Type,
                Amount = dto.Amount,
                Status = "Đang chờ duyệt",
                Victim = dto.Victim,
                Tags = dto.Tags,
                Facebook = dto.Facebook,
                Images = dto.Images,
                CreatedAt = DateTime.UtcNow,
                Category = (ScamCategory)dto.Category
            };

            _context.ScamReports.Add(report);
            await _context.SaveChangesAsync();

            return MapToDto(report);
        }

        public async Task<bool> ApproveReportAsync(string id)
        {
            var report = await _context.ScamReports.FindAsync(id);
            if (report == null) return false;

            report.Status = "Đã phê duyệt";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateReportAsync(string id, UpdateScamReportDto dto)
        {
            var report = await _context.ScamReports.FindAsync(id);
            if (report == null) return false;

            report.Name = dto.Name;
            report.Phone = dto.Phone;
            report.BankName = dto.BankName;
            report.AccountNumber = dto.AccountNumber;
            report.Desc = dto.Desc;
            report.Type = dto.Type;
            report.Amount = dto.Amount;
            report.Victim = dto.Victim;
            report.Facebook = dto.Facebook;
            report.Tags = dto.Tags;
            report.Images = dto.Images;
            report.Category = (ScamCategory)dto.Category;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectReportAsync(string id)
        {
            var report = await _context.ScamReports.FindAsync(id);
            if (report == null) return false;

            _context.ScamReports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ScamReportDto>> GetAllAsync()
        {
            var reports = await _context.ScamReports.ToListAsync();
            return reports.Select(MapToDto);
        }

        private static ScamReportDto MapToDto(ScamReport report)
        {
            return new ScamReportDto
            {
                Id = report.Id,
                Name = report.Name,
                Phone = report.Phone,
                BankName = report.BankName,
                AccountNumber = report.AccountNumber,
                Desc = report.Desc,
                Type = report.Type,
                Amount = report.Amount,
                Status = report.Status,
                Victim = report.Victim,
                Tags = report.Tags,
                Facebook = report.Facebook,
                Images = report.Images,
                CreatedAt = report.CreatedAt,
                Category = (int)report.Category
            };
        }
    }
}
