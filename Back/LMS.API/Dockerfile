FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["LMS.API/LMS.API.csproj", "LMS.API/"]
RUN dotnet restore "LMS.API/LMS.API.csproj"
COPY . .
WORKDIR "/src/LMS.API"
RUN dotnet build "LMS.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LMS.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LMS.API.dll"]