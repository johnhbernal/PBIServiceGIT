# Agents — PBIServiceGIT (teaching lab)

## Identity

- **Service:** PBIServices — inventory / PBI-style API for **practice and teaching**
- **Stack:** .NET 10 · EF Core **InMemory** · JWT · **simulated** directory
- **Peers:** Practica stack lessons (secrets, AuthZ default, honest AD claims)

## Hard rules

1. **No real connections** — no corporate SQL, no real LDAP/AD binds, no production hosts.
2. Default `App:DataProvider=InMemory`. `SqlServer` must remain blocked.
3. Seed only fake demo data (`TeachingDataSeeder`).
4. Do not invent MRR/product features; keep the lab focused on AuthN/AuthZ + sample reads.
5. Prefer edit over create; keep files focused.

## Scope

| In scope | Out of scope |
|----------|----------------|
| Teaching AuthN/AuthZ, health, CI, Docker | Wiring real enterprise DBs |
| Simulated directory (Practica-style honesty) | Claiming production LDAP |
| Demo seed users | Copying real customer data |

## Piso transversal

Skill personal `redtic-software-practices` ([Red-TIC UNAM](https://www.red-tic.unam.mx/desarrollo-de-software)) — req → diseño → construcción → QA → release → config. No sustituye las fichas de este repo.

**Push:** commits locales libres; `git push` solo con autorización explícita de Hawer (o cuando dé la tarea por cerrada y el gate esté verde). Un gate verde no autoriza. Este repo no despliega: el push solo corre CI. Y desde el 2026-10-22, **una tarea = un commit publicado = un push**: al cerrar se aplastan los commits locales a uno y el push es uno solo.
