using Google.GenAI;
using AIEmailGenerator.API.Models;

namespace AIEmailGenerator.API.Services
{
    public class EmailGeneratorService : IEmailGeneratorService
    {
        private readonly Client _client;
        public EmailGeneratorService(IConfiguration configuration)
        {
            var apiKey = configuration["Gemini:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException(
                    "Gemini API key is not configured.");
            }

            _client = new Client(apiKey: apiKey);
        }
        public async Task<string> GenerateEmailAsync(EmailRequest request)
        {
            var prompt = $"""
                You are a professional email-writing assistant.

                Generate an email using the following details:

                Purpose: {request.Purpose}
                Recipient: {request.Recipient}
                Key points: {request.KeyPoints}
                Tone: {request.Tone}

                Include a suitable subject line and email body.
                Do not invent facts that were not provided.
                """;

            var response = await _client.Models.GenerateContentAsync(
                model: "gemini-3.5-flash-lite",
                contents: prompt);

            var generatedEmail = response.Candidates?
                .FirstOrDefault()?.Content?.Parts?
                .FirstOrDefault()?.Text;

            if (string.IsNullOrWhiteSpace(generatedEmail))
            {
                throw new InvalidOperationException(
                    "Gemini returned an empty response.");
            }

            return generatedEmail;
        }

    }
}
