using System.Collections.Generic;
using System.Threading.Tasks;
using CheckZone.Api.DTOs;

namespace CheckZone.Api.Services
{
    public interface IScamReportService
    {
        Task<IEnumerable<ScamReportDto>> GetAllApprovedAsync();
        Task<IEnumerable<ScamReportDto>> GetWarningsAsync();
        Task<ScamReportDto?> GetByIdAsync(string id);
        Task<ScamReportDto> SubmitReportAsync(CreateScamReportDto dto);
        Task<bool> ApproveReportAsync(string id);
        Task<bool> RejectReportAsync(string id);
        Task<IEnumerable<ScamReportDto>> GetAllAsync();
    }
}
