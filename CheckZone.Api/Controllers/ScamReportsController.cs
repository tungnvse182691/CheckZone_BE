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
    public class ScamReportsController : ControllerBase
    {
        private readonly IScamReportService _scamReportService;

        public ScamReportsController(IScamReportService scamReportService)
        {
            _scamReportService = scamReportService;
        }

        [HttpGet("public/scams")]
        public async Task<ActionResult<IEnumerable<ScamReportDto>>> GetScams()
        {
            var result = await _scamReportService.GetAllApprovedAsync();
            return Ok(result);
        }

        [HttpGet("public/warnings")]
        public async Task<ActionResult<IEnumerable<ScamReportDto>>> GetWarnings()
        {
            var result = await _scamReportService.GetWarningsAsync();
            return Ok(result);
        }

        [HttpGet("public/scams/{id}")]
        public async Task<ActionResult<ScamReportDto>> GetById(string id)
        {
            var result = await _scamReportService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("public/reports/submit")]
        public async Task<ActionResult<ScamReportDto>> SubmitReport([FromBody] CreateScamReportDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _scamReportService.SubmitReportAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize]
        [HttpPut("admin/scams/{id}/approve")]
        public async Task<IActionResult> ApproveReport(string id)
        {
            var success = await _scamReportService.ApproveReportAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }

        [Authorize]
        [HttpDelete("admin/scams/{id}/reject")]
        public async Task<IActionResult> RejectReport(string id)
        {
            var success = await _scamReportService.RejectReportAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }

        [Authorize]
        [HttpGet("admin/scams")]
        public async Task<ActionResult<IEnumerable<ScamReportDto>>> GetAdminScams()
        {
            var result = await _scamReportService.GetAllAsync();
            return Ok(result);
        }
    }
}
