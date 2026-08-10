# Teaching lab image — InMemory seed, no external DB/LDAP.
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY PBIServices.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development
ENV App__DataProvider=InMemory
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PBIServices.dll"]
