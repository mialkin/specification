INFRASTRUCTURE_FILE := docker-compose.infrastructure.yml
STARTUP_PROJECT := src/Specification.Api
DATABASE_PROJECT := src/Specification.Infrastructure.Implementation.Database

.PHONY: copy-env
copy-env:
	cp -n .env.example .env | true

.PHONY: run
run:
	dotnet run --project $(STARTUP_PROJECT)

.PHONY: watch
watch:
	dotnet watch --project $(STARTUP_PROJECT) --no-hot-reload

.PHONY: run-infrastructure
run-infrastructure: copy-env
	docker compose --file $(INFRASTRUCTURE_FILE) up

.PHONY: shutdown-infrastructure
shutdown-infrastructure:
	docker compose --file $(INFRASTRUCTURE_FILE) down

.PHONY: migrate-database
migrate-database:
	dotnet ef migrations add $(name) \
        --project $(DATABASE_PROJECT) \
        --startup-project $(STARTUP_PROJECT) \
        -- --environment $(environment)

.PHONY: update-database
update-database:
	dotnet ef database update \
        --project $(DATABASE_PROJECT) \
        --startup-project $(STARTUP_PROJECT) \
        -- --environment $(environment)

.PHONY: list-migrations
list-migrations:
	dotnet ef migrations list \
        --project $(DATABASE_PROJECT) \
        --startup-project $(STARTUP_PROJECT)
