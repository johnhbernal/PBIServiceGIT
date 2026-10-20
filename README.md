# PBIServices — teaching lab

.NET Web API for learning AuthN/AuthZ and PBI-style read APIs.

**This repo is for practice and teaching only.**  
It uses **InMemory EF data** + a **simulated directory**. It must **not** connect to corporate SQL Server, real LDAP, or production hosts.

Lessons aligned with the Practica portfolio (`ms-auth` · `practica` · `ms-frontend` · `practica-stack`).

## What is simulated

| Concern | Teaching behavior |
|---------|-------------------|
| Database | EF Core **InMemory** + seed (`TeachingDataSeeder`) |
| Directory / AD | `SimulatedDirectoryService` (no network) |
| SQL Server provider | **Blocked** at startup if `App:DataProvider=SqlServer` |
| Secrets | Demo JWT key only in Development; never real corp passwords |

## Stack

| | |
|---|---|
| Runtime | .NET **10** |
| AuthN | JWT (`POST /api/Token`) |
| AuthZ | Fallback authenticated + `[Authorize]` on data APIs |
| Health | `GET /health` (anonymous) |

## Quick start (offline)

```powershell
cd C:\Proyectos\PBIServiceGIT
dotnet restore
dotnet run --project PBIServices.csproj
```

1. `POST /api/Token`  
   ```json
   { "email": "admin@demo.local", "password": "Admin123!" }
   ```
2. `GET /api/Lineas` with header `Authorization: Bearer <token>`
3. Without token → **401**

### Demo users (seed)

| Email | Password | Directory user |
|-------|----------|----------------|
| `admin@demo.local` | `Admin123!` | `admin` |
| `seller@demo.local` | `Seller123!` | `seller` |

## Security / honesty

- Old commits may still contain real connection strings in history — **rotate** anything that was ever live; this tree no longer ships them.
- Password compare in seed is plaintext **for teaching only**.
- See [`.ai/SECURITY.md`](.ai/SECURITY.md) · [`.ai/ACTIVE-DIRECTORY.md`](.ai/ACTIVE-DIRECTORY.md) · [`.ai/AGENTS.md`](.ai/AGENTS.md).

## Tests

```powershell
dotnet test PBIServices.sln -c Release
```

`tests/PBIServices.Tests` boots the real `Startup` with `WebApplicationFactory` (InMemory +
simulated directory) and pins the lesson: `/health` anonymous, `/api/Lineas` **401** without a
token, bad credentials **401**, missing fields **400**, and the seeded `admin@demo.local` token
opening `/api/Lineas` with **200**. The CI job runs it after the build.

Dependency audit: `dotnet list PBIServices.csproj package --vulnerable --include-transitive`
must report **no vulnerable packages** (two transitive High advisories are pinned out in
`PBIServices.csproj`).

## Related portfolio

| Repo | Role |
|------|------|
| [practica-stack](https://github.com/johnhbernal/practica-stack) | Compose + council |
| [ms-auth](https://github.com/johnhbernal/ms-auth) | JWT + RBAC + AD **sim** |
| [practica](https://github.com/johnhbernal/practica) | Parameters API |
| [ms-frontend](https://github.com/johnhbernal/ms-frontend) | React SPA |
