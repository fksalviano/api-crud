# Api-CRUD

.Net 9 API crud sample using Mediator pattern with MediatR, Commands, Handlers and valiadtions with Handlers PipelineBehavior.

Using Minimal API approach mapping Endpoints instead of Controllers with Scalar for API documentation without Swagger.

Data access with Dapper and DapperExtensions to generate and execute CRUD SQL commands.

Using SQLite Database in memory.

### Handlers

- **GetWeatherHandler**:
    Handler based on the sample .net template API WeatherForecast to Get All or Get by Id based on the command sended by API request.

- **SaveWeatherHandler**:
    Handler to Create or Update Wheaters based on the command sended by API request.

- **RemoveWeatherHandler**:
    Handler to Delete Wheaters based on the command sended by API request.

### API

The API micro-service with the Endpoints, using minimal api endpoints mapping.

## Tests

- **Unit Tests**:
    Tests for each class and methods independently.

- **Integration Tests**:
    Tests for each endpoint call testing the integration of all classes and methods.

## Configuration

### Requirements

Need to install the follow:

- Git:
    https://git-scm.com/downloads

- Dotnet Core 9.0 SDK and Runtime:
    https://dotnet.microsoft.com/en-us/download/dotnet/9.0


## Getting Started

#### Clone the repository:

```bash
git clone https://github.com/fksalviano/api-crud.git
```

#### Go to the project directory

```bash
cd api-crud
```

#### Build the project

```bash
dotnet build
```

#### Run the project

```bash
dotnet run --project src/API
```

## Packages

The project uses the following packages

- MediatR:
    https://www.nuget.org/packages/MediatR

- Dapper:
    https://www.nuget.org/packages/Dapper

- DapperExtensions:
    https://www.nuget.org/packages/DapperExtensions    

- Scalar:
    https://www.nuget.org/packages/Scalar.AspNetCore

- FluentValidation:
    https://www.nuget.org/packages/fluentvalidation

- FluentAssertions:
    https://www.nuget.org/packages/fluentassertions

- XUnit:
    https://www.nuget.org/packages/xunit

- AutoFixture:
    https://www.nuget.org/packages/autofixture

- Moq.AutoMock:
    https://www.nuget.org/packages/moq.automock
