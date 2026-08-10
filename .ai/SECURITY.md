# Security — teaching lab

## Applied (from Practica)

1. Secrets / hosts out of committed config (no real SQL passwords).
2. AuthZ by default (`FallbackPolicy` + `[Authorize]`).
3. Short-lived JWT (`Jwt:ExpirationMinutes`).
4. Login dump endpoint disabled (`SecurityController`).
5. **Data plane is InMemory** — no live DB credentials required to run.

## Teaching AuthN (honest)

| Step | Behavior |
|------|----------|
| Seeded `UserInfo` | Email/password match on **demo** rows only |
| Directory | `SimulatedDirectoryService` — allow-list of demo usernames |
| JWT | HS256 teaching key in Development |

## Forbidden in this lab

- Pointing `ConnectionStrings` at corporate servers
- Enabling real `System.DirectoryServices` binds
- Committing `.env` with real secrets
- Restoring historical passwords/IPs into `appsettings.json`
