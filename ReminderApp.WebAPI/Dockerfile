# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReminderApp.WebAPI/ReminderApp.WebAPI.csproj", "ReminderApp.WebAPI/"]
COPY ["ReminderApp.Infrastructure/ReminderApp.Infrastructure.csproj", "ReminderApp.Infrastructure/"]
COPY ["ReminderApp.Application/ReminderApp.Application.csproj", "ReminderApp.Application/"]
COPY ["ReminderApp.Domain/ReminderApp.Domain.csproj", "ReminderApp.Domain/"]
RUN dotnet restore "./ReminderApp.WebAPI/ReminderApp.WebAPI.csproj"
COPY . .
WORKDIR "/src/ReminderApp.WebAPI"
RUN dotnet build "./ReminderApp.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build



# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ReminderApp.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReminderApp.WebAPI.dll"]