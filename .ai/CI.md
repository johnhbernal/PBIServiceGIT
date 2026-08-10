# CI — teaching lab

- Target: .NET 10 on `ubuntu-latest`
- `dotnet restore` + `dotnet build -c Release`
- No integration tests against external SQL/LDAP (none configured)

Local:

```powershell
dotnet build -c Release
dotnet run --project PBIServices.csproj
```
