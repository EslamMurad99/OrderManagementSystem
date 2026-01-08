# OrderManagementSystem
Order Management System API use Clean Architecture 
Architecture Overview 
This solution implements a small Order Management System using Clean Architecture 
principles, Domain-Driven Design (DDD), SOLID principles, and strict separation of 
concerns. The focus is on code quality, maintainability, and demonstrating key concepts 
without over-engineering. 
Key Decisions 
• Clean Architecture Layers: 
o Domain: Contains entities (e.g., Product, Order, Customer), value objects 
(e.g., Money), enums (e.g., OrderStatus), and business logic. No 
dependencies on external frameworks or infrastructure. Business rules (e.g., 
price validation, order modification restrictions) are enforced here to avoid 
an anemic domain model. 
o Application: Defines interfaces for repositories, DTOs, and application 
services (use cases). Handles orchestration of domain logic and data access 
via repository interfaces. Uses CQRS-like patterns with services for 
commands and queries. 
o Infrastructure: Implements repositories using Entity Framework Core and a 
relational database (SQLite for simplicity). Handles persistence concerns. 
o API: ASP.NET Core Web API with thin controllers that delegate to application 
services. No business logic here.
