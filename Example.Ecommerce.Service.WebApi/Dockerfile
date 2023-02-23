#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Example.Ecommerce.Service.WebApi/Example.Ecommerce.Service.WebApi.csproj", "Example.Ecommerce.Service.WebApi/"]
COPY ["Example.Ecommerce.Application.DTO/Example.Ecommerce.Application.DTO.csproj", "Example.Ecommerce.Application.DTO/"]
COPY ["Example.Ecommerce.Application.Interface/Example.Ecommerce.Application.Interface.csproj", "Example.Ecommerce.Application.Interface/"]
COPY ["Example.Ecommerce.Transversal.Common/Example.Ecommerce.Transversal.Common.csproj", "Example.Ecommerce.Transversal.Common/"]
COPY ["Example.Ecommerce.Application.Main/Example.Ecommerce.Application.Main.csproj", "Example.Ecommerce.Application.Main/"]
COPY ["Example.Ecommerce.Application.Validator/Example.Ecommerce.Application.Validator.csproj", "Example.Ecommerce.Application.Validator/"]
COPY ["Example.Ecommerce.Domain.Entity/Example.Ecommerce.Domain.Entity.csproj", "Example.Ecommerce.Domain.Entity/"]
COPY ["Example.Ecommerce.Domain.Interface/Example.Ecommerce.Domain.Interface.csproj", "Example.Ecommerce.Domain.Interface/"]
COPY ["Example.Ecommerce.Domain.Core/Example.Ecommerce.Domain.Core.csproj", "Example.Ecommerce.Domain.Core/"]
COPY ["Example.Ecommerce.Infrastructure.Interface/Example.Ecommerce.Infrastructure.Interface.csproj", "Example.Ecommerce.Infrastructure.Interface/"]
COPY ["Example.Ecommerce.Infrastructure.Data/Example.Ecommerce.Infrastructure.Data.csproj", "Example.Ecommerce.Infrastructure.Data/"]
COPY ["Example.Ecommerce.Infrastructure.Repository/Example.Ecommerce.Infrastructure.Repository.csproj", "Example.Ecommerce.Infrastructure.Repository/"]
COPY ["Example.Ecommerce.Transversal.Logging/Example.Ecommerce.Transversal.Logging.csproj", "Example.Ecommerce.Transversal.Logging/"]
COPY ["Example.Ecommerce.Transversal.Mapper/Example.Ecommerce.Transversal.Mapper.csproj", "Example.Ecommerce.Transversal.Mapper/"]
RUN dotnet restore "Example.Ecommerce.Service.WebApi/Example.Ecommerce.Service.WebApi.csproj"
COPY . .
WORKDIR "/src/Example.Ecommerce.Service.WebApi"
RUN dotnet build "Example.Ecommerce.Service.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Ecommerce.Service.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Ecommerce.Service.WebApi.dll"]