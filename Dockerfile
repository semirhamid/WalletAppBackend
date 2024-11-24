# Use official .NET SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app

# Copy solution and restore dependencies
COPY WalletAppBackend.sln ./
COPY WalletApp.API/WalletApp.API.csproj ./WalletApp.API/
COPY WalletApp.Application/WalletApp.Application.csproj ./WalletApp.Application/
COPY WalletApp.Domain/WalletApp.Domain.csproj ./WalletApp.Domain/
COPY WalletApp.Infrastructure/WalletApp.Infrastructure.csproj ./WalletApp.Infrastructure/
COPY WalletApp.Persistence/WalletApp.Persistence.csproj ./WalletApp.Persistence/
RUN dotnet restore

# Copy everything and build the application
COPY . ./
RUN dotnet publish WalletApp.API/WalletApp.API.csproj -c Release -o out

# Use official ASP.NET Core Runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# Expose port and start the application
EXPOSE 5000
ENTRYPOINT ["dotnet", "WalletApp.API.dll"]
