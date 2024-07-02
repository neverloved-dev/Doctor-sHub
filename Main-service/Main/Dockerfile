# Use the official ASP.NET core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Main.csproj", "./"]
RUN dotnet restore "./Main.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Main.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Main.dll"]
