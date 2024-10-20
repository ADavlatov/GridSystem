FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 7076
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["/GridSystem.Client.csproj", "/GridSystem.Client.csproj"]
RUN dotnet restore "/GridSystem.Client.csproj"
COPY . .
WORKDIR "/src/GridSystem.Client"
RUN dotnet build "/src/GridSystem.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/GridSystem.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GridSystem.Client.dll"]
