#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Recipes.API/Recipes.API.csproj", "Recipes.API/"]
RUN dotnet restore "Recipes.API/Recipes.API.csproj"
COPY . .
WORKDIR "/src/Recipes.API"
RUN dotnet build "Recipes.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recipes.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recipes.API.dll"]