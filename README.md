# dotnet-works

## Overview

**dotnet-works** is a .NET-based application environment configured for development and testing with a MySQL backend. The project leverages Docker Compose to orchestrate the application and its database dependencies, providing a reproducible and isolated environment for development.

## Project Structure

- **Dockerfile**: (Not shown here) Used to build the .NET application container.
- **docker-compose.yaml**: Defines and manages multi-container Docker applications, including the .NET app and MySQL database.
- **dataprotection/**: Directory mounted into the .NET container for ASP.NET Data Protection keys.
- **initdb/**: Directory for MySQL initialization scripts, mounted into the MySQL container.
- **mysql-data/**: Docker-managed volume for persistent MySQL data.

## Services

### dotnet (bridge-mall-app)
- **Builds from:** Local Dockerfile.
- **Ports:** Exposes port 8080 inside the container as 8000 on the host.
- **Environment:** Sets `ASPNETCORE_ENVIRONMENT=Development`.
- **Volumes:** Persists ASP.NET Data Protection keys.
- **Depends on:** `mysql` service.

### mysql (mysql-db)
- **Image:** `mysql:8.0`
- **Ports:** Exposes MySQL on port 3306.
- **Environment Variables:**
  - `MYSQL_ROOT_PASSWORD`
  - `MYSQL_DATABASE`
  - `MYSQL_USER`
  - `MYSQL_PASSWORD`
- **Volumes:**
  - Persists database data.
  - Runs initialization scripts from `initdb/` on first startup.

## Getting Started

### Prerequisites

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/)

### Running the Application

1. Clone the repository:
   ```sh
   git clone <repository-url>
   cd dotnet-works
   ```

2. Place your .NET application source and Dockerfile in the project root if not already present.

3. (Optional) Add MySQL initialization scripts to the `initdb/` directory.

4. Start the services:
   ```sh
   docker-compose up --build
   ```

5. Access the .NET application at [http://localhost:8000](http://localhost:8000).

### Stopping the Application

```sh
docker-compose down
```

## Data Persistence

- MySQL data is stored in a Docker-managed volume (`mysql-data`).
- ASP.NET Data Protection keys are persisted in the `dataprotection/` directory.

## Customization

- Update environment variables in `docker-compose.yaml` as needed.
- Add or modify MySQL initialization scripts in `initdb/`.
- Adjust port mappings if required.

## License

This project is provided as-is for development and educational purposes.