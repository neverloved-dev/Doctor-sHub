# Use the official ASP.NET core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8090

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Authenticator.csproj", "./"]
RUN dotnet restore "./Authenticator.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Authenticator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authenticator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authenticator.dll"]
