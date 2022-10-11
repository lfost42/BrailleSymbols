#https://keepinguptodate.com/pages/2020/12/net5-aspnet-docker-mac/

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY *.sln .
COPY ["Braille.API/Braille.API.csproj", "Braille.API/"]
COPY ["Braille.Data/Braille.Data.csproj", "Braille.Data/"]
RUN dotnet restore

COPY . .
WORKDIR /src/Braille.API
RUN dotnet publish -c Release -o /src/BrailleAPI --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /src/BrailleAPI
COPY --from=build /src/BrailleAPI .
ENTRYPOINT ["dotnet", “Braille.API.dll"]