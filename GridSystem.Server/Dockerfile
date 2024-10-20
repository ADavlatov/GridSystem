FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["/GridSystem.Server.csproj", "/GridSystem.Server.csproj"]
RUN dotnet restore "/GridSystem.Server.csproj"
COPY . .
WORKDIR "/src/GridSystem.Server"
RUN dotnet build "/src/GridSystem.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/GridSystem.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GridSystem.Server.dll"]
