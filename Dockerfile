FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /scr
COPY ["UPC.PMS.API/UPC.PMS.API.csproj", "UPC.PMS.API/"]
COPY ["UPC.PMS.BL/UPC.PMS.BL.csproj", "UPC.PMS.BL/"]
COPY ["UPC.PMS.DA/UPC.PMS.DA.csproj", "UPC.PMS.DA/"]
RUN dotnet restore "UPC.PMS.API/UPC.PMS.API.csproj"
COPY . .
WORKDIR "/scr/UPC.PMS.API"
RUN dotnet build "UPC.PMS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UPC.PMS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "UPC.PMS.API.dll"]

