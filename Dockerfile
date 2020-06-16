#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /BrentAdmin
COPY ["BrentWiels/BrentWiels.csproj", "BrentWiels/"]
COPY ["Documents/Documents.csproj", "Documents/"]
COPY ["DataLayer/DataLayer.csproj", "DataLayer/"]
RUN dotnet restore "BrentWiels/BrentWiels.csproj"
COPY . .
WORKDIR "/BrentAdmin/BrentWiels"
RUN dotnet build "BrentWiels.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrentWiels.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrentWiels.dll"]