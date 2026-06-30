using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CheckZone.Api.DTOs;
using CheckZone.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace CheckZone.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ScamReportsController : ControllerBase
    {
        private readonly IScamReportService _scamReportService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ScamReportsController(
            IScamReportService scamReportService,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _scamReportService = scamReportService;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
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

            if (!await ValidateTurnstileToken(dto.TurnstileToken ?? ""))
            {
                return BadRequest(new { message = "Xác minh mã CAPTCHA người máy thất bại hoặc không hợp lệ." });
            }

            var result = await _scamReportService.SubmitReportAsync(dto);
            return Created($"/api/public/scams/{result.Id}", result);
        }

        private async Task<bool> ValidateTurnstileToken(string token)
        {
            var secretKey = _configuration["Turnstile:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                // Fallback to test key
                secretKey = "1x00000000000000000000000000000000";
            }

            // Cloudflare test secret keys always pass — bypass real validation
            if (secretKey.StartsWith("1x0000000000"))
            {
                return true;
            }

            var httpClient = _httpClientFactory.CreateClient();
            var values = new Dictionary<string, string>
            {
                { "secret", secretKey },
                { "response", token }
            };

            try
            {
                var content = new FormUrlEncodedContent(values);
                var response = await httpClient.PostAsync("https://challenges.cloudflare.com/turnstile/v0/siteverify", content);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                var jsonResult = await response.Content.ReadFromJsonAsync<TurnstileResponse>();
                return jsonResult?.Success ?? false;
            }
            catch
            {
                return false;
            }
        }

        private class TurnstileResponse
        {
            [System.Text.Json.Serialization.JsonPropertyName("success")]
            public bool Success { get; set; }
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
        [HttpPut("admin/scams/{id}")]
        public async Task<IActionResult> UpdateReport(string id, [FromBody] UpdateScamReportDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _scamReportService.UpdateReportAsync(id, dto);
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
