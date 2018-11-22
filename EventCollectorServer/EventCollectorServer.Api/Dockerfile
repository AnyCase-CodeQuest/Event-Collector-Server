FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["EventCollectorServer.Api/EventCollectorServer.Api.csproj", "EventCollectorServer.Api/"]
RUN dotnet restore "EventCollectorServer.Api/EventCollectorServer.Api.csproj"
COPY . .
WORKDIR "/src/EventCollectorServer.Api"
RUN dotnet build "EventCollectorServer.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EventCollectorServer.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EventCollectorServer.Api.dll"]