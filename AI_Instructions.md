# AI Developer Instructions for OberstoneERP

## Project Structure Overview
The workspace is organized into several projects, separated by domain and database type. This structure indicates a layered, multi-database architecture.

**Solution Root:** `C:\Users\eeaqu\source\repos\OberstoneERP\`
**Solution File:** `OberstoneERP.slnx`

### Projects
1.  **`OberstoneERP`**: The main application logic/API project. This likely contains the core business logic and serves as the entry point for most requests.
2.  **`OberstoneERP.Data.Entities`**: Contains the core data model definitions (Entities). This project is fundamental and should be depended upon by all data access layers, promoting single source of truth for models.
3.  **`OberstoneERP.Data.PostgreSQL`**, **`OberstoneERP.Data.MariaDB`**, **`OberstoneERP.Data.MSSQL`**: These are database-specific data access layers. They implement the necessary persistence logic (e.g., repository patterns, context setup) for their respective database types (PostgreSQL, MariaDB, MSSQL). They likely depend on `OberstoneERP.Data.Entities`.

## Architectural Patterns and Conventions
*   **Multi-Database Support:** The inclusion of separate data layer projects for PostgreSQL, MariaDB, and MSSQL confirms that the application is designed to support multiple SQL backends, allowing for database vendor flexibility or migration paths without massive code changes.
*   **Layering:** The `Entities` project acting as a dependency for the specific data providers suggests adherence to a clean separation of concerns (Domain/Model Layer -> Infrastructure/Persistence Layer).
*   **Target Framework:** All projects target **.NET 10**. Future modifications must maintain compatibility with the specified target framework.
*   **Code Style Guidance:** Use established .NET conventions (e.g., naming conventions, dependency injection pattern if applicable).

## Key Assumptions for Development
1.  **Dependency Flow:** Core business logic (`OberstoneERP`) depends on the data models (`OberstoneERP.Data.Entities`), and data access repositories depend on both the models and the specific database provider.
2.  **Persistence Abstraction:** There must be an abstraction layer (e.g., an interface in `OberstoneERP.Data.Entities`) that is implemented differently in each specialized data project (`...PostgreSQL`, `...MariaDB`, etc.). Changes to core interfaces must be propagated across all implementing data projects.
3.  **Build/Test:** When making changes, always consider the impact on *all* database layers, even if the change is conceptually related to one.

## Best Practices for Future Development
*   **Consistency:** Maintain consistency across all database implementations regarding API usage and model serialization.
*   **Testing Strategy:** Focus on writing unit tests for business logic and integration tests (using in-memory databases or dedicated test containers) for the data access layers.
*   **Change Management:** If modifying a core entity or API contract, document the impact on the database abstraction layer (`I*Repository` interfaces).