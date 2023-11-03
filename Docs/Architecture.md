# Clean Architecture Approach for a .NET Betting Application

## 1. Presentation Layer
- Web API Project (GamblerX.API)
  - Built using .NET 7
  - Single file (program.cs) for configuration
  - External gateway for API requests
- Contracts Project (GamblerX.Contracts)
  - define the structure and format of data that the API expects as input and returns as output

## 2. Infrastructure Layer
- Class Library Project (GamblerX.Infrastructure)
  - Provides infrastructure-related functionalities
  - Provides data interaction functionalities
  - Registers its own dependencies for dependency injection

## 3. Application Layer
- Class Library Project (GamblerX.Application)
  - Contains application-specific logic
  - Depends on the Domain layer
  - Defines various Interfaces 
  - Used by Infrastructure layer

## 4. Domain Layer
- Class Library Project (GamblerX.Domain)
  - Defines the core domain logic

### Dependencies
- API Project (GamblerX.API) depends on:
  - Contracts Project (GamberX.Contracts)
  - Application Project (GamberX.Application)
  - Infrastructure Project (GamberX.Infrastructure)
- Infrastructure Project (GamberX.Infrastructure) depends on:
  - Application Project (GamberX.Application)
- Application Project (GamberX.Application) depends on:
  - Domain Project (GamberX.Domain)
- API Project (GamberX.API) also depends on:
  - Infrastructure Project (GamberX.Infrastructure)
