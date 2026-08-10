# Active Directory — teaching simulation

## Honesty

This lab does **not** talk to a real domain controller.

| Mode | Implementation |
|------|----------------|
| Current | `SimulatedDirectoryService` — in-process allow-list (`admin`, `seller`, `demo.user`) |
| Legacy | Real `DirectoryEntry` / LDAP path — **removed from runtime** for teaching safety |

Git history may mention “LDAP funcional”; treat that as historical. Portfolio demos must say **simulated directory**, same honesty as Practica `ms-auth`.

## Flags

`Ldap:Mode=Simulated`, `Ldap:Enabled=true` — directory check runs against the simulator.  
`Ldap:Path` values like `SIMULATED://demo.local/` are documentary only.
