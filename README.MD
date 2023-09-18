# start

## Create DB

```bash
docker compose  up -d
```

## Build && Install && migrate

```bash
dotnet build
```

```bash
dotnet ef migrations add InitialCreate
```

```bash
dotnet ef database update
```

## run

```bash
dotnet watch run
```
