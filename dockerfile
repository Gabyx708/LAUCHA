FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet build "Laucha.api/LAUCHA.api.csproj" -c Release -o /app/build

RUN dotnet publish "LAUCHA.api/LAUCHA.api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY  --from=build-env /app/publish .

EXPOSE 7135

ENTRYPOINT [ "dotnet","LAUCHA.api.dll" ]