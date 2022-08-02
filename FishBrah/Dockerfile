FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FishBrah/FishBrah.csproj", "FishBrah/"]
RUN dotnet restore "FishBrah/FishBrah.csproj"
COPY . .
WORKDIR "/src/FishBrah"
RUN dotnet build "FishBrah.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FishBrah.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FishBrah.dll"]
