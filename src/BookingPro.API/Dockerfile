#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookingPro.API/BookingPro.API.csproj", "BookingPro.API/"]
COPY ["BookingPro.Domain/BookingPro.Domain.csproj", "BookingPro.Domain/"]
COPY ["BookingPro.Infrastructure.Database/BookingPro.Infrastructure.Database.csproj", "BookingPro.Infrastructure.Database/"]
RUN dotnet restore "BookingPro.API/BookingPro.API.csproj"
COPY . .
WORKDIR "/src/BookingPro.API"
RUN dotnet build "BookingPro.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookingPro.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookingPro.API.dll"]