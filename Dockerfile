FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MetricExample.Api/MetricExample.Api.csproj", "MetricExample.Api/"]
RUN dotnet restore "MetricExample.Api/MetricExample.Api.csproj"
COPY . .
WORKDIR "/src/MetricExample.Api"
RUN dotnet build "MetricExample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetricExample.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "MetricExample.Api.dll"]
