FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Production

WORKDIR /app

COPY /. ./

RUN dotnet build src/Worker/Worker.csproj

WORKDIR /app
RUN dotnet publish src/Worker/Worker.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime

ENV ASPNETCORE_ENVIRONMENT=Production

WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "Worker.dll"]