# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Zkopíruj soubory
COPY . ./

# Publish projektu
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Spusť aplikaci
ENTRYPOINT ["dotnet", "c#-mat-zad.dll"]
