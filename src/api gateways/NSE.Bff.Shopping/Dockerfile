#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./api gateways/NSE.Bff.Shopping/NSE.Bff.Shopping.csproj", "api gateways/NSE.Bff.Shopping/"]
COPY ["./building blocks/NSE.Core/NSE.Core.csproj", "building blocks/NSE.WebApi.Core/"]
COPY ["./building blocks/NSE.WebApi.Core/NSE.WebApi.Core.csproj", "building blocks/NSE.WebApi.Core/"]
COPY ["./building blocks/NSE.MessageBus/NSE.MessageBus.csproj", "building blocks/NSE.MessageBus/"]

RUN dotnet restore "api gateways/NSE.Bff.Shopping/NSE.Bff.Shopping.csproj"
COPY . .
WORKDIR "api gateways/NSE.Bff.Shopping"
RUN dotnet build "NSE.Bff.Shopping.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Bff.Shopping.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Bff.Shopping.dll"]