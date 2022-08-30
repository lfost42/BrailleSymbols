#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Braille.API/Braille.API.csproj", "Braille.API/"]
RUN dotnet restore "Braille.API/Braille.API.csproj"
COPY . .
WORKDIR "/src/Braille.API"
RUN dotnet build "Braille.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Braille.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Braille.API.dll"]