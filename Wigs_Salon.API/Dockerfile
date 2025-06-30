# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Wigs_Salon.API/Wigs_Salon.API.csproj", "Wigs_Salon.API/"]
COPY ["WigsS_Salon.BL/WigsS_Salon.BL.csproj", "WigsS_Salon.BL/"]
COPY ["Wigs_Salon.DAL/Wigs_Salon.DAL.csproj", "Wigs_Salon.DAL/"]
RUN dotnet restore "./Wigs_Salon.API/Wigs_Salon.API.csproj"
COPY . .
WORKDIR "/src/Wigs_Salon.API"
RUN dotnet build "./Wigs_Salon.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Wigs_Salon.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wigs_Salon.API.dll"]