# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EmployeesService.Api/EmployeesService.Api.csproj", "EmployeesService.Api/"]
COPY ["EmployeeService.Application/EmployeeService.Application.csproj", "EmployeeService.Application/"]
COPY ["EmployeeService.Domain/EmployeeService.Domain.csproj", "EmployeeService.Domain/"]
COPY ["EmployeeService.DataAccess/EmployeeService.DataAccess.csproj", "EmployeeService.DataAccess/"]
RUN dotnet restore "./EmployeesService.Api/EmployeesService.Api.csproj"
COPY . .
WORKDIR "/src/EmployeesService.Api"
RUN dotnet build "./EmployeesService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EmployeesService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeesService.Api.dll"]