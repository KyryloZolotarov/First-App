FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
# Install NodeJs and npm
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs
# End Install
WORKDIR /src
COPY ["Web/web.client/nuget.config", "Web/web.client/"]
COPY ["Web/Web.Server/Web.Server.csproj", "Web/Web.Server/"]
COPY ["Web/web.client/web.client.esproj", "Web/web.client/"]
COPY ["Infrastructure/Infrastructure/Infrastructure.csproj", "Infrastructure/Infrastructure/"]
RUN dotnet restore "./Web/Web.Server/./Web.Server.csproj"
COPY . .
WORKDIR "/src/Web/Web.Server"
RUN dotnet build "./Web.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Server.dll"]