# AI Email Generator

An AI-powered email generation application built using ASP.NET Core Web API, C#, and Google Gemini.

## Project Overview

AI Email Generator helps users create professional emails based on their purpose, recipient, key points, and preferred tone.

The application uses Google Gemini to generate email content and provides a simple web interface to display and copy the generated email.

## Technologies Used

- C#
- ASP.NET Core Web API (.NET 8)
- Interface-based service architecture
- Dependency Injection
- Google Gemini API
- HTML, CSS, JavaScript
- xUnit
- Moq
- Swagger / OpenAPI

## Features

- Generate emails using AI.
- Select email tone: Professional, Friendly, Formal, or Casual.
- Validate user inputs using Data Annotations.
- Handle unexpected errors using custom middleware.
- Copy generated emails to the clipboard.
- Asynchronous API communication.
- Unit testing using xUnit and Moq.

## Project Structure

```text
AIEmailGenerator
│
├── AIEmailGenerator.API
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Middleware
│   ├── wwwroot
│   │   └── index.html
│   └── Program.cs
│
├── AIEmailGenerator.Tests
│   ├── EmailControllerTests.cs
│   └── EmailRequestTests.cs
│
└── README.md
```

## Configuration

This project uses Google Gemini API for AI-powered email generation.

1. Create a Gemini API key from [Google AI Studio](https://aistudio.google.com/app/apikey).
2. Configure the API key using .NET User Secrets:

```bash
dotnet user-secrets set "Gemini:ApiKey" "YOUR_API_KEY"
```
**Note:** Never commit your actual API key to GitHub or store it directly in the source code.

## How to Run the Project

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK
- Google Gemini API key

### Steps

1. Clone the repository:

```bash
git clone YOUR_GITHUB_REPOSITORY_URL
```

2. Open the solution in Visual Studio.

3. Configure the Gemini API key using User Secrets.

4. Set `AIEmailGenerator.API` as the startup project.

5. Run the application.

6. Open the application URL in your browser.

### Run Unit Tests

Execute the following command from the solution folder:

```bash
dotnet test
```

This runs the unit tests in the test project.

## Future Enhancements

- Add more email templates.
- Improve the user interface.
- Expand unit test coverage.
- Add support for additional AI-powered features.