using System.Collections.Generic;
using System.Threading.Tasks;
using CheckZone.Api.DTOs;

namespace CheckZone.Api.Services
{
    public interface ILegitProfileService
    {
        Task<IEnumerable<LegitProfileDto>> GetAllAsync();
        Task<LegitProfileDto?> GetByIdAsync(int id);
        Task<LegitProfileDto> CreateProfileAsync(CreateLegitProfileDto dto);
        Task<bool> DeleteProfileAsync(int id);
    }
}
