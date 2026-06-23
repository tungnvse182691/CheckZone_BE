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
    public class LegitProfileService : ILegitProfileService
    {
        private readonly AppDbContext _context;

        public LegitProfileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LegitProfileDto>> GetAllAsync()
        {
            var profiles = await _context.LegitProfiles.ToListAsync();
            return profiles.Select(MapToDto);
        }

        public async Task<LegitProfileDto?> GetByIdAsync(int id)
        {
            var profile = await _context.LegitProfiles.FindAsync(id);
            return profile == null ? null : MapToDto(profile);
        }

        public async Task<LegitProfileDto> CreateProfileAsync(CreateLegitProfileDto dto)
        {
            var profile = new LegitProfile
            {
                Name = dto.Name,
                Role = dto.Role,
                Score = dto.Score,
                Img = dto.Img,
                Desc = dto.Desc,
                Phone = dto.Phone,
                Telegram = dto.Telegram,
                Insurance = dto.Insurance,
                SuccessTrans = dto.SuccessTrans,
                JoinDate = dto.JoinDate,
                BusinessType = dto.BusinessType
            };

            _context.LegitProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return MapToDto(profile);
        }

        public async Task<bool> DeleteProfileAsync(int id)
        {
            var profile = await _context.LegitProfiles.FindAsync(id);
            if (profile == null) return false;

            _context.LegitProfiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }

        private static LegitProfileDto MapToDto(LegitProfile profile)
        {
            string tier;
            if (profile.Insurance >= 500000000m)
            {
                tier = "Hạng Kim Cương";
            }
            else if (profile.Insurance >= 100000000m)
            {
                tier = "Hạng Bạch Kim";
            }
            else
            {
                tier = "Hạng Vàng";
            }

            return new LegitProfileDto
            {
                Id = profile.Id,
                Name = profile.Name,
                Role = profile.Role,
                Score = profile.Score,
                Img = profile.Img,
                Desc = profile.Desc,
                Phone = profile.Phone,
                Telegram = profile.Telegram,
                Insurance = profile.Insurance,
                SuccessTrans = profile.SuccessTrans,
                JoinDate = profile.JoinDate,
                BusinessType = profile.BusinessType,
                Tier = tier
            };
        }
    }
}
