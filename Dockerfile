FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore
WORKDIR /src/HospitalManagement.Api
RUN dotnet publish "HospitalManagement.Api.csproj" -c release -o /app/out

FROM base AS final
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "HospitalManagement.Api.dll"]