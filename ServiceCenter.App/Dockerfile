FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ServiceCenter.App/ServiceCenter.App.csproj", "ServiceCenter.App/"]
RUN dotnet restore "ServiceCenter.App/ServiceCenter.App.csproj"
COPY . .
WORKDIR "/src/ServiceCenter.App"
RUN dotnet build "ServiceCenter.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceCenter.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceCenter.App.dll"]