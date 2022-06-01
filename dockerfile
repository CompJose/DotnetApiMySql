FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app-dotnet 

COPY . ./

RUN dotnet restore
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app-dotnet
COPY --from=build-env /app-dotnet/out .
ENTRYPOINT [ "dotnet", "API.dll" ]
