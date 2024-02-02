FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tektonlabs.Ecommerce.WebApi/Tektonlabs.Ecommerce.WebApi.csproj", "Tektonlabs.Ecommerce.WebApi/"]
COPY ["Tektonlabs.Ecommerce.Application.DTO/Tektonlabs.Ecommerce.Application.DTO.csproj", "Tektonlabs.Ecommerce.Application.DTO/"]
COPY ["Tektonlabs.Ecommerce.Common/Tektonlabs.Ecommerce.Common.csproj", "Tektonlabs.Ecommerce.Common/"]
COPY ["Tektonlabs.Ecommerce.Application.Interface/Tektonlabs.Ecommerce.Application.Interface.csproj", "Tektonlabs.Ecommerce.Application.Interface/"]
COPY ["Tektonlabs.Ecommerce.Domain/Tektonlabs.Ecommerce.Domain.csproj", "Tektonlabs.Ecommerce.Domain/"]
COPY ["Tektonlabs.Ecommerce.Application.UseCases/Tektonlabs.Ecommerce.Application.UseCases.csproj", "Tektonlabs.Ecommerce.Application.UseCases/"]
COPY ["Tektonlabs.Ecommerce.Infrastructure/Tektonlabs.Ecommerce.Infrastructure.csproj", "Tektonlabs.Ecommerce.Infrastructure/"]
COPY ["Tektonlabs.Ecommerce.Persistencia/Tektonlabs.Ecommerce.Persistencia.csproj", "Tektonlabs.Ecommerce.Persistencia/"]

RUN dotnet restore "./Tektonlabs.Ecommerce.WebApi/./Tektonlabs.Ecommerce.WebApi.csproj"

COPY . .
WORKDIR "/src/Tektonlabs.Ecommerce.WebApi"
RUN dotnet build "./Tektonlabs.Ecommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tektonlabs.Ecommerce.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tektonlabs.Ecommerce.WebApi.dll"]