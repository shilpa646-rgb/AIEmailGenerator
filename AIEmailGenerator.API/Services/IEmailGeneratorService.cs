using AIEmailGenerator.API.Models;

namespace AIEmailGenerator.API.Services
{
    public interface IEmailGeneratorService
    {
        Task<string> GenerateEmailAsync(EmailRequest request);
    }
}
