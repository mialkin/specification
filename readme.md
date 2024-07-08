# Specification

## Prerequisites

- [↑ .NET SDK 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [↑ EF Core command-line tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- [↑ Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [↑ GNU Make](https://www.gnu.org/software/make)

## How to use project

### 1. Set up infrastructure

```bash
make run-infrastructure
```

```bash
make migrate-database name="Add_Initial_Migration" environment="Ide"
```

```bash
make update-database environment="Ide"
```

### 2. Run application

```bash
make run
```
or:

```bash
make watch
```

### 3. Tear down infrastructure

```bash
make shutdown-infrastructure
```
