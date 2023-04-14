# базовый образ, с которого будем запускать приложение
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app
EXPOSE 80

# 1 - сборка приложения
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /source
# 1.1 копируем проект API со всеми зависимостями
COPY ["BookingPro.Domain/BookingPro.Domain.csproj", "BookingPro.Domain/"]
COPY ["BookingPro.Infrastructure.Database/BookingPro.Infrastructure.Database.csproj", "BookingPro.Infrastructure.Database/"]
COPY ["BookingPro.API/BookingPro.API.csproj", "BookingPro.API/"]
# 1.2 восстанавливаем пакеты
RUN dotnet restore "BookingPro.API/BookingPro.API.csproj"

# 1.3 копируем все исходники и билдим приложение
COPY . .
WORKDIR /source/BookingPro.API
RUN dotnet build "BookingPro.API.csproj" -c Release -o /app/build

# 2 - публикация приложения
FROM build as publish
RUN dotnet publish "BookingPro.API.csproj" -c Release -o /app/publish

# 2 - запуск
FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "BookingPro.API.dll"]