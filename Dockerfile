# Use the official Microsoft .NET Core SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copy the solution file and individual project files 
COPY src/src.sln .
COPY src/HP-Player-Console.Api/ HP-Player-Console.Api/
COPY src/HP-Player-Console.Application/ HP-Player-Console.Application/
COPY src/HP-Player-Console.Common/ HP-Player-Console.Common/
COPY src/HP-Player-Console.Infrastructure/ HP-Player-Console.Infrastructure/
# Restore NuGet packages for the entire solution
RUN dotnet restore


# Copy everything else and build
COPY . ./
RUN dotnet publish HP-Player-Console.Api -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

Expose 8080

ENTRYPOINT ["dotnet", "HP-Player-Console.Api.dll"]

