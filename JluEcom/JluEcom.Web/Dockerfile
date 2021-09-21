#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["JluEcom.Web/JluEcom.Web.csproj", "JluEcom.Web/"]
RUN dotnet restore "JluEcom.Web/JluEcom.Web.csproj"
COPY . .
WORKDIR "/src/JluEcom.Web"
RUN dotnet build "JluEcom.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JluEcom.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JluEcom.Web.dll"]