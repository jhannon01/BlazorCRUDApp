# Clean Architecture Refactoring Plan for BlazorCRUDApp

This plan outlines the steps to refactor the existing BlazorCRUDApp into a Clean Architecture structure with three projects: `BlazorCRUDApp.Core`, `BlazorCRUDApp.Infrastructure`, and `BlazorCRUDApp.Web`. The goal is to separate concerns: Core for business logic, Infrastructure for data and external dependencies, and Web for the UI.

## Project Structure Overview

-  **BlazorCRUDApp.Core**: Contains entities, interfaces, and core business logic services.
-  **BlazorCRUDApp.Infrastructure**: Handles data access, migrations, and external services (repository implementations).
-  **BlazorCRUDApp.Web**: The Blazor WebAssembly/Server app with pages and components.

## Step-by-Step Refactoring Plan

### 1. Create New Projects

-  Create a new solution file (e.g., `BlazorCRUDApp.sln`) in the root directory.
-  Add three new class library projects:
   -  `BlazorCRUDApp.Core` (Class Library)
   -  `BlazorCRUDApp.Infrastructure` (Class Library)
   -  `BlazorCRUDApp.Web` (Blazor Web App, Interactive Server)
-  Move the existing `BlazorCRUDApp.csproj` content to `BlazorCRUDApp.Web.csproj` and update references.

### 2. Move Entities to Core

-  Create `Entities` folder in `BlazorCRUDApp.Core`.
-  Move `Entities/Song.cs`, `Entities/LibrarySong.cs`, and `Entities/SongSearchModel.cs` to `BlazorCRUDApp.Core/Entities/`.
-  Update namespaces to `BlazorCRUDApp.Core.Entities`.

### 3. Define Interfaces in Core

-  Create `Interfaces` folder in `BlazorCRUDApp.Core`.
-  Extract interfaces from services:
   -  Create `ISongService.cs` with methods like `Task<List<Song>> GetAll()`, `Task Add(Song song)`, etc.
   -  Create `ILibraryService.cs` with methods like `Task<List<LibrarySong>> SearchByTitle(string title)`.
-  Define repository interfaces for data access:
   -  Create `ISongRepository.cs` with methods like `Task<List<Song>> GetAllAsync()`, `Task AddAsync(Song song)`, etc.
   -  Create `ILibraryRepository.cs` with methods like `Task<List<LibrarySong>> SearchByTitleAsync(string title)`.

### 4. Create Business Logic Services in Core

-  Create `Services` folder in `BlazorCRUDApp.Core`.
-  Create `SongService.cs` and `LibraryService.cs` in `BlazorCRUDApp.Core/Services/`.
-  Implement `ISongService` and `ILibraryService` in these classes.
-  These services will contain the business logic and depend on repository interfaces (e.g., `ISongRepository` and `ILibraryRepository`).
-  Update namespaces to `BlazorCRUDApp.Core.Services`.

### 5. Move Data and Implement Repositories in Infrastructure

-  Create `Data` folder in `BlazorCRUDApp.Infrastructure`.
-  Move `Data/AppDbContext.cs` to `BlazorCRUDApp.Infrastructure/Data/`.
-  Move `Migrations` folder to `BlazorCRUDApp.Infrastructure/Migrations/`.
-  Create `Repositories` folder in `BlazorCRUDApp.Infrastructure`.
-  Create `SongRepository.cs` and `LibraryRepository.cs` in `BlazorCRUDApp.Infrastructure/Repositories/`.
-  Implement `ISongRepository` and `ILibraryRepository` in these classes using `AppDbContext`.
-  Update namespaces to `BlazorCRUDApp.Infrastructure.Data` and `BlazorCRUDApp.Infrastructure.Repositories`.

### 6. Move UI Components to Web

-  Move `Components`, `Pages`, `Layout`, `Helpers`, and `Routes` folders to `BlazorCRUDApp.Web/Components/`.
-  Move `wwwroot` and `wwwroot/app.css` to `BlazorCRUDApp.Web/wwwroot/`.
-  Update `Program.cs` in `BlazorCRUDApp.Web` to register services from Infrastructure.
-  Add project references: `BlazorCRUDApp.Web` references `BlazorCRUDApp.Core` and `BlazorCRUDApp.Infrastructure`.

### 7. Update Dependencies and Configurations

-  In `Program.cs`, add:
   ```csharp
   builder.Services.AddScoped<ISongRepository, SongRepository>();
   builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
   builder.Services.AddScoped<ISongService, SongService>();
   builder.Services.AddScoped<ILibraryService, LibraryService>();
   ```
-  Ensure `appsettings.json` and connection strings are in `BlazorCRUDApp.Web`.
-  Update all `@using` directives in Razor files to reference the new namespaces (e.g., `BlazorCRUDApp.Core.Entities`).

### 8. Handle Shared Code

-  Move shared utilities (if any) to `BlazorCRUDApp.Core`.
-  Update any cross-references between projects.

### 9. Testing and Validation

-  Build and run the solution.
-  Test CRUD operations in `Components/Pages/Songs.razor`, `Components/Pages/AddSong.razor`, and `Components/Pages/FindSong.razor`.
-  Verify migrations work with `dotnet ef database update` in Infrastructure.

### 10. Final Cleanup

-  Remove old files from the root project.
-  Update `.gitignore` and build scripts as needed.
-  Document any breaking changes in a README.md.

This plan assumes Entity Framework migrations are handled in Infrastructure. Adjust for specific tooling. If issues arise, refer to the [Clean Architecture sample](https://github.com/dotnet-architecture/eShopOnWeb).
