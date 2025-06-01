# Poznámková aplikace (ASP.NET Core MVC)

Tato aplikace slouží pro správu soukromých textových poznámek. Uživatelé si mohou poznámky vytvářet, mazat, označovat jako důležité, filtrovat a mohou také zrušit svůj účet.

## Použité technologie

- ASP.NET Core MVC (.NET 7 nebo 8)
- Entity Framework Core (SQLite databáze)
- Bootstrap 5 (styly)
- Session pro přihlášení
- Hashování hesel (`IPasswordHasher<T>`)

---

## Spuštění aplikace

1. **Klonuj repozitář**

2. **Obnovení NuGet balíčků:**
	dotnet restore