FROM mcr.microsoft.comdotnetaspnet6.0 AS base
WORKDIR app
EXPOSE 80

FROM mcr.microsoft.comdotnetsdk6.0 AS build
WORKDIR src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o apppublish

FROM base AS final
WORKDIR app
COPY --from=build apppublish .
ENTRYPOINT [dotnet, c#-mat-zad.dll]
