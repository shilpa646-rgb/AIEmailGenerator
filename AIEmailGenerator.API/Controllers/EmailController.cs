using Microsoft.AspNetCore.Mvc;
using AIEmailGenerator.API.Models;
using AIEmailGenerator.API.Services;

namespace AIEmailGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailGeneratorService _emailGeneratorService;

        public EmailController(IEmailGeneratorService emailGeneratorService)
        {
            _emailGeneratorService = emailGeneratorService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateEmail(
            [FromBody] EmailRequest request)
        {
            var email = await _emailGeneratorService.GenerateEmailAsync(request);

            return Ok(new { generatedEmail = email });
        }

    }
}
