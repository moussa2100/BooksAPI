#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApplication61/WebApplication61.csproj", "WebApplication61/"]
RUN dotnet restore "WebApplication61/WebApplication61.csproj"
COPY . .
WORKDIR "/src/WebApplication61"
RUN dotnet build "WebApplication61.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication61.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplication61.dll"]