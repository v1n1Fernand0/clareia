FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Clareia.API/Clareia.API.csproj", "Clareia.API/"]
COPY ["Clareia.Application/Clareia.Application.csproj", "Clareia.Application/"]
COPY ["Clareia.Domain/Clareia.Domain.csproj", "Clareia.Domain/"]
COPY ["Clareia.Infrastructure/Clareia.Infrastructure.csproj", "Clareia.Infrastructure/"]
RUN dotnet restore "Clareia.API/Clareia.API.csproj"

COPY . .
WORKDIR "/src/Clareia.API"
RUN dotnet build "Clareia.API.csproj" -c Release -o /app/build
RUN dotnet publish "Clareia.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Clareia.API.dll"]
