#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["../Better.Web.WeChat/Better.Web.WeChat.csproj", "../Better.Web.WeChat/"]
RUN dotnet restore "../Better.Web.WeChat/Better.Web.WeChat.csproj"
COPY . .
WORKDIR "/src/../Better.Web.WeChat"
RUN dotnet build "Better.Web.WeChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Better.Web.WeChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Better.Web.WeChat.dll"]