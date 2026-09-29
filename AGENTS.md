# AztecDateTranslator Codebase Guide

## 🚀 Overview
This solution translates Gregorian dates into Aztec calendar cycles (Tonalpohualli and Xiuhpohualli). It is structured as a multi-project solution using .NET MAUI for the UI and a dedicated Console app for utility/testing.

## 🏗️ Architecture
*   **Pattern:** MVVM (Model-View-ViewModel) for the UI layer.
*   **Layers:**
    1.  **Presentation:** `AztecDateTranslator` (MAUI App)
    2.  **Business Logic/Service:** `AztecDateTranslator.Shared` (Contains `IDateTranslator` and implementations).
    3.  **Data Access:** `AztecDateTranslator.Shared` (Contains `AztecContext` for EF Core).
    4.  **Utility:** `AztecDateTranslator.Console` (CLI entry point).

## ⚙️ Development Conventions
*   **Dependency Injection (DI):** All services must be registered in `MauiProgram.cs`. Use `AddTransient` for services and `AddScoped` for ViewModels.
*   **Service Contracts:** Always interact with core logic through interfaces (e.g., `IDateTranslator`) to ensure testability and loose coupling.
*   **Database:** Use `AztecContext` for all persistence operations. Initialization and seeding must be handled in `MauiProgram.cs`.

## 🛠️ Build & Deployment
*   **Build Command:** `dotnet build -c Release --packages <path> AztecDateTranslator.slnx`
*   **Test Command:** Use `dotnet test` (xUnit framework assumed).
*   **CI/CD:** The pipeline is defined in `.gitlab-ci.yml` and targets the `Release` stage.

## ⚠️ Pitfalls & Gotchas
1.  **Platform Code:** Be mindful of the `#if` preprocessor directives in `MauiProgram.cs` as they control platform-specific behavior.
2.  **Shared Dependency:** Changes to `AztecDateTranslator.Shared` models or interfaces require coordinated updates across all consuming projects.
3.  **Database Context:** Ensure the `AztecContext.DbPath` is correctly resolved for the target environment (e.g., mobile vs. desktop).