# lang-master — Language Learning App

App for improving language skills (Polish → English learning). .NET 8 Web API backend, single-service deploy to **Railway** (Railway Postgres). A frontend is not yet chosen — when added, build it to static files served from the API's `wwwroot` so it ships in the same container/service (Blazor is the other option). The old Angular starter was removed.

## Layout

```
lang-master/
└── LanguageLearningAPI/          # .NET 8 Web API (the whole app)
    ├── Controllers/ApiController.cs   # CRUD for all 4 entities
    ├── Models/                        # User, LearningPlan, TranslationGroup, TranslationPair
    ├── Data/ApplicationDbContext.cs   # EF Core DbContext (Npgsql/Postgres)
    ├── Repositories/DatabaseRepository.cs  # generic EF repository
    ├── Migrations/                    # EF Core migrations (InitialCreate)
    ├── Data/DbSeeder.cs               # idempotent startup seed (sample groups/pairs)
    ├── Program.cs                     # DI + auto-applies migrations + seeds on startup
    ├── wwwroot/                       # static frontend (index.html/app.js/styles.css) served by the API
    ├── Dockerfile                     # multi-stage build; Railway deploys from this
    ├── docker-compose.yml             # local dev: API + postgres:17-alpine
    ├── appsettings.json               # dead Cloud SQL string; overridden by env var on Railway
    └── .ai/                           # PLANNING DOCS — read these for intent (PRDs, db, deployment)
```

## Build / Run

From `LanguageLearningAPI/`:
```
dotnet build                   # compiles; no DB needed
dotnet ef migrations add <Name>  # add a migration after model changes
```

Two ways to run locally — both serve the frontend + API + Swagger from one process:

**1. Full stack in containers** (production-like; the whole app + DB):
```
docker compose up --build      # or: podman compose up --build -d   (this machine uses Podman)
# App on http://localhost:8080  (frontend at /, Swagger at /swagger)
# podman: if `podman compose` can't find the file, pass -f <abs path>/docker-compose.yml
# stop: docker|podman compose down     (add -v to also wipe the DB + reseed)
```

**2. IDE / Kestrel** (faster C# inner loop — no image rebuild):
```
docker|podman compose up -d db   # start ONLY Postgres (published on localhost:5432)
# then Run the "http" (or "https") profile in your IDE, or:
dotnet run --launch-profile http
# App on http://localhost:5211
```
The `http`/`https` launch profiles (`Properties/launchSettings.json`) set the
`ConnectionStrings__DefaultConnection` env var to the compose Postgres. There is **no IIS
Express profile** — it's not installed/needed; the app runs on Kestrel everywhere.

## Architecture notes

- **Data model** is specified in `LanguageLearningAPI/.ai/db/db-instructions.md` (canonical SQL). EF entities mirror it:
  - `Users` (UserID, Username unique, PasswordHash, UserType enum Admin/Learner)
  - `LearningPlan` (PlanID, UserID FK, **GroupIDs = JSONB** list of group ids)
  - `TranslationGroups` (GroupID, GroupName, Description, **SourceLanguage/TargetLanguage** = ISO 639-1 codes, default `pl`/`en`)
  - `TranslationPairs` (PairID, GroupID FK, SourceContent, TargetContent, Type enum word/phrase/sentence) — content is language-agnostic; the language pair lives on the parent `TranslationGroup`, so the app supports any source→target pair, not just Polish→English
- Enums (`UserType`, `ContentType`) are persisted **as strings** via `HasConversion<string>()` to match the SQL CHECK constraints.
- `DatabaseRepository` is a generic EF wrapper (`AddEntityAsync<T>`, `GetEntityByIdAsync<T>`, etc.); `ApiController` exposes REST CRUD per the spec in `.ai/app/api-specification.md`.
- Schema is provisioned by the **`InitialCreate` EF migration** (mirrors the canonical SQL), applied automatically via `db.Database.Migrate()` on startup.

## Deployment (Railway)

Same pattern as the `coin-collector` project: Railway deploys from the `Dockerfile`, a Railway Postgres plugin supplies the DB.
- Service **Root Directory** = `LanguageLearningAPI`.
- Set service var `ConnectionStrings__DefaultConnection` referencing the Postgres service:
  `Host=${{Postgres.PGHOST}};Port=${{Postgres.PGPORT}};Database=${{Postgres.PGDATABASE}};Username=${{Postgres.PGUSER}};Password=${{Postgres.PGPASSWORD}};SslMode=Require;Trust Server Certificate=true` — this overrides the dead Cloud SQL string in `appsettings.json`.
- App listens on `http://+:8080`; `UseHttpsRedirection` is dev-only (Railway terminates TLS at its edge). Swagger is enabled in all environments.

## Status (as of 2026-06-13)

- ✅ Backend builds clean (0 errors/0 warnings) and is fully wired (DI + controllers + Swagger).
- ✅ `InitialCreate` EF migration in place; auto-applied on startup.
- ✅ Dockerized + Railway-ready (Dockerfile, .dockerignore, docker-compose for local dev).
- ⬜ Not yet verified end-to-end against a running container/DB (Docker daemon was down at setup time).
- ⬜ No authentication yet (MVP calls for basic login/registration — see `.ai/app/app-mvp.md`).
- ⬜ No frontend yet (Angular starter removed; plan is static SPA in `wwwroot` or Blazor).
- ⬜ No tests (planned: xUnit backend).

## Conventions

- The `.cursor/rules/senior-dev.mdc` rule exists but is empty (no active guidance).
- All product/design intent lives under `LanguageLearningAPI/.ai/` (prds, app, db, deployment) — consult before adding features.
