FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish HospitalManagementApi -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 443
EXPOSE 80

ENTRYPOINT ["dotnet", "HospitalManagementApi.dll"]