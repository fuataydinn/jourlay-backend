# ======================
# 1. Base runtime image
# ======================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# ======================
# 2. Build stage
# ======================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Proje dosyalarýný kopyala
COPY ["Jourlay.API/Jourlay.API.csproj", "Jourlay.API/"]
COPY ["Jourlay.Application/Jourlay.Application.csproj", "Jourlay.Application/"]
COPY ["Jourlay.Domain/Jourlay.Domain.csproj", "Jourlay.Domain/"]
COPY ["Jourlay.Infrastructure/Jourlay.Infrastructure.csproj", "Jourlay.Infrastructure/"]
COPY ["Jourlay.Persistence/Jourlay.Persistence.csproj", "Jourlay.Persistence/"]

# NuGet restore
RUN dotnet restore "Jourlay.API/Jourlay.API.csproj"

# Tüm kaynak kodlarý kopyala
COPY . .

# Build
WORKDIR "/src/Jourlay.API"
RUN dotnet build "Jourlay.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ======================
# 3. Publish stage
# ======================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Jourlay.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ======================
# 4. Final stage
# ======================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Yayýnlanan uygulama dosyalarýný kopyala
COPY --from=publish /app/publish .

EXPOSE 8080
EXPOSE 8081

# Uygulamayý çalýþtýr
ENTRYPOINT ["dotnet", "Jourlay.API.dll"]
