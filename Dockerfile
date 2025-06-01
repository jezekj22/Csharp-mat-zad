# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Zkopíruju jen csproj (kvůli cachování restore)
COPY ./c#-mat-zad/c#-mat-zad.csproj ./c#-mat-zad/
RUN dotnet restore ./c#-mat-zad/c#-mat-zad.csproj

# Zkopíruju zbytek projektu
COPY . .

# Publish projektu
RUN dotnet publish ./c#-mat-zad/c#-mat-zad.csproj -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "c#-mat-zad.dll"]
