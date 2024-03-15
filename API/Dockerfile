FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY Theater.sln .
COPY Models/*.csproj Models/
COPY Business/*.csproj Business/
COPY Data/*.csproj Data/
COPY API/*.csproj API/
COPY Logging/*.csproj Logging/
RUN dotnet restore Theater.sln

COPY . .
RUN dotnet publish Theater.sln -c Release -o API/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/API/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "Theater.API.dll"]