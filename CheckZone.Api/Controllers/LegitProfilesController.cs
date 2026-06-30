using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckZone.Api.DTOs;
using CheckZone.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace CheckZone.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class LegitProfilesController : ControllerBase
    {
        private readonly ILegitProfileService _legitProfileService;

        public LegitProfilesController(ILegitProfileService legitProfileService)
        {
            _legitProfileService = legitProfileService;
        }

        [HttpGet("public/legit")]
        public async Task<ActionResult<IEnumerable<LegitProfileDto>>> GetLegitProfiles()
        {
            var result = await _legitProfileService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("public/legit/{id}")]
        public async Task<ActionResult<LegitProfileDto>> GetById(int id)
        {
            var result = await _legitProfileService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost("admin/legit")]
        public async Task<ActionResult<LegitProfileDto>> CreateProfile([FromBody] CreateLegitProfileDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _legitProfileService.CreateProfileAsync(dto);
            return Created($"/api/public/legit/{result.Id}", result);
        }

        [Authorize]
        [HttpDelete("admin/legit/{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var success = await _legitProfileService.DeleteProfileAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
