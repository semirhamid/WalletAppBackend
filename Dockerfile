# Use official .NET SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copy the solution file and restore dependencies
COPY WalletAppBackend.sln ./ 
COPY src/WalletApp.API/WalletApp.API.csproj ./src/WalletApp.API/
COPY src/WalletApp.Application/WalletApp.Application.csproj ./src/WalletApp.Application/
COPY src/WalletApp.Domain/WalletApp.Domain.csproj ./src/WalletApp.Domain/
COPY src/WalletApp.Infrastructure/WalletApp.Infrastructure.csproj ./src/WalletApp.Infrastructure/
COPY src/WalletApp.Persistence/WalletApp.Persistence.csproj ./src/WalletApp.Persistence/

RUN dotnet restore

# Copy everything from the src directory and build the application
COPY src/ ./src/
RUN dotnet publish src/WalletApp.API/WalletApp.API.csproj -c Release -o /app/out

# Use official ASP.NET Core Runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/out ./

# Expose port and start the application
EXPOSE 5000
ENTRYPOINT ["dotnet", "WalletApp.API.dll"]
