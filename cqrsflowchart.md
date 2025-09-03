---
config:
  layout: dagre
---
flowchart TB
 subgraph API["PatientManagement.Api"]
        Controller["Controllers\n(Endpoints REST)"]
  end
 subgraph APP["PatientManagement.Application"]
        Command["Commands"]
        CommandHandler["Command Handlers"]
        Query["Queries"]
        QueryHandler["Query Handlers"]
  end
 subgraph DOMAIN["PatientManagement.Domain"]
        Entity["Entities / Aggregates"]
        ValueObj["Value Objects"]
        Events["Domain Events"]
        RepositoryInterface["IRepository Interfaces"]
  end
 subgraph INFRA["PatientManagement.Infrastructure"]
        Repository["Repository Implementations"]
        DbContext["DbContext (EF Core)"]
        Migrations["Migrations"]
  end
    Controller --> Command & Query
    Command --> CommandHandler
    Query --> QueryHandler
    CommandHandler --> RepositoryInterface & Entity
    QueryHandler --> RepositoryInterface & Entity
    RepositoryInterface --> Repository
    Repository --> DbContext
    DbContext --> Migrations
    Entity --> Events & ValueObj
