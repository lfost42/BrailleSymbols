FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build

ENV ASPNETCORE_URLS http://*:44319

ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 44319

WORKDIR /src
COPY ["Braille.API/Braille.API.csproj", "Braille.API/"]
COPY ["Braille.Data/Braille.Data.csproj", "Braille.Data/"]
RUN dotnet restore "Braille.API/Braille.API.csproj"
COPY . .
WORKDIR "/src/Braille.API"
RUN dotnet build "Braille.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Braille.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet Braille.API.dll