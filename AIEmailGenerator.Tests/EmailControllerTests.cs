using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using AIEmailGenerator.API.Controllers;
using AIEmailGenerator.API.Models;
using AIEmailGenerator.API.Services;

namespace AIEmailGenerator.Tests
{
    public class EmailControllerTests
    {
        [Fact]
        public async Task GenerateEmail_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IEmailGeneratorService>();

            var request = new EmailRequest
            {
                Purpose = "Apply for Senior .NET Developer position",
                Recipient = "HR Team",
                KeyPoints = "13 years of .NET experience",
                Tone = "Professional"
            };

            var expectedEmail = "Subject: Job Application";

            mockService
                .Setup(service => service.GenerateEmailAsync(request))
                .ReturnsAsync(expectedEmail);

            var controller = new EmailController(mockService.Object);

            // Act
            var result = await controller.GenerateEmail(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expectedEmail,
                okResult.Value?.GetType()
                    .GetProperty("generatedEmail")?
                    .GetValue(okResult.Value));

            mockService.Verify(
                service => service.GenerateEmailAsync(request),
                Times.Once);
        }

        [Fact]
        public async Task GenerateEmail_WhenServiceThrowsException_PropagatesException()
        {
            // Arrange
            var mockService = new Mock<IEmailGeneratorService>();

            var request = new EmailRequest
            {
                Purpose = "Job Application",
                Recipient = "HR Team",
                KeyPoints = "13 years of .NET experience",
                Tone = "Professional"
            };

            mockService
                .Setup(service => service.GenerateEmailAsync(request))
                .ThrowsAsync(new InvalidOperationException("Test exception"));

            var controller = new EmailController(mockService.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => controller.GenerateEmail(request));

            Assert.Equal("Test exception", exception.Message);
        }

    }
}
