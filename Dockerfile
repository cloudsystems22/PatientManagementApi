# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia os csproj primeiro
COPY src/PatientManagement.Api/PatientManagement.Api.csproj src/PatientManagement.Api/
COPY src/PatientManagement.Application/PatientManagement.Application.csproj src/PatientManagement.Application/
COPY src/PatientManagement.Infrastructure/PatientManagement.Infrastructure.csproj src/PatientManagement.Infrastructure/
COPY src/PatientManagement.Domain/PatientManagement.Domain.csproj src/PatientManagement.Domain/

RUN dotnet restore "src/PatientManagement.Api/PatientManagement.Api.csproj"

# Copia o restante do código
COPY . .

WORKDIR /src/src/PatientManagement.Api
RUN dotnet build "./PatientManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatientManagement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientManagement.Api.dll"]
