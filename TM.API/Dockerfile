## stage 1. build api ##
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS api-build-stage
WORKDIR /TM.API

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as api-runtime
WORKDIR /TM.API
EXPOSE 5000
COPY --from=api-build-stage /TM.API/out .
ENTRYPOINT ["dotnet", "TM.API.dll"]


