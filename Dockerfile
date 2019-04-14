FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Example.OData.Api/Example.OData.Api.csproj", "Example.OData.Api/"]
RUN dotnet restore "Example.OData.Api/Example.OData.Api.csproj"
COPY . .
WORKDIR "/src/Example.OData.Api"
RUN dotnet build "Example.OData.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Example.OData.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Example.OData.Api.dll"]