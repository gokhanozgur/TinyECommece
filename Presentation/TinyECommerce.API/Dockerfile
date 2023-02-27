FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/TinyECommerce.API/TinyECommerce.API.csproj", "Presentation/TinyECommerce.API/"]
RUN dotnet restore "Presentation/TinyECommerce.API/TinyECommerce.API.csproj"
COPY . .
WORKDIR "/src/Presentation/TinyECommerce.API"
RUN dotnet build "TinyECommerce.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TinyECommerce.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TinyECommerce.API.dll"]
