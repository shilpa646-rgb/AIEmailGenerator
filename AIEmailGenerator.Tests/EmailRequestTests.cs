using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AIEmailGenerator.API.Models;
using Xunit;

namespace AIEmailGenerator.Tests
{
    public class EmailRequestTests
    {
        [Fact]
        public void EmailRequest_WithValidData_PassesValidation()
        {
            // Arrange
            var request = new EmailRequest
            {
                Purpose = "Job Application",
                Recipient = "HR Team",
                KeyPoints = "13 years of .NET experience",
                Tone = "Professional"
            };

            // Act
            var results = ValidateModel(request);

            // Assert
            Assert.Empty(results);
        }

        [Fact]
        public void EmailRequest_WithInvalidTone_FailsValidation()
        {
            // Arrange
            var request = new EmailRequest
            {
                Purpose = "Job Application",
                Recipient = "HR Team",
                KeyPoints = "13 years of .NET experience",
                Tone = "Funny"
            };

            // Act
            var results = ValidateModel(request);

            // Assert
            Assert.NotEmpty(results);
        }

        [Fact]
        public void EmailRequest_WithMissingPurpose_FailsValidation()
        {
            // Arrange
            var request = new EmailRequest
            {
                Purpose = "",
                Recipient = "HR Team",
                KeyPoints = "13 years of .NET experience",
                Tone = "Professional"
            };

            // Act
            var results = ValidateModel(request);

            // Assert
            Assert.NotEmpty(results);
        }

        private static List<ValidationResult> ValidateModel(
            EmailRequest request)
        {
            var context = new ValidationContext(request);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(
                request,
                context,
                results,
                validateAllProperties: true);

            return results;
        }

    }
}
