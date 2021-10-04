#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ARG APPLICATION_CRIMSON_ARG
ARG CHURCH_PINK_ARG
ENV APPLICATION_CRIMSON_ARG=$APPLICATION_CRIMSON_ARG
ENV ADMIN_EMAIL=$CHURCH_PINK_ARG

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["KoreanKirklandCentralChurch.csproj", "./"]
RUN dotnet restore "./KoreanKirklandCentralChurch.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "KoreanKirklandCentralChurch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KoreanKirklandCentralChurch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet KoreanKirklandCentralChurch.dll