# Api-Clean-VS

.Net Core API sample using Clean Architecture and Vertical Slice

Architecture implemented to isolate the Application Common Domain from each Use Case Domain.

### Use Cases

- **GetWeatherForecast**: 
    Sample use case based on the sample .net API.
    
### Worker

The API micro-service with the Controllers and endpoints.

### Dependency Injection

The project uses Dependence Injection to build the container services and uses self-installers to add each Use Case on the container independently.

## Configuration

### Requirements

Need to install the follow:

- Git:
    https://git-scm.com/downloads

- Dotnet Core 7.0 SDK and Runtime:
    https://dotnet.microsoft.com/en-us/download/dotnet/7.0
    

## Getting Started

#### Clone the repository:

```bash
git clone https://github.com/fksalviano/api-clean-vs.git 
```

#### Go to the project directory

```bash
cd api-clean-vs
```

#### Build the project

```bash
dotnet build
```

#### Run the project

```bash
dotnet run --project src/Worker
```

## Packages

The project uses the following packages

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
