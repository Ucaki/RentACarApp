Rent a car (client-server application)
        
  **Overview**:


-This project is a client-server desktop application for managing a rent-a-car system. It supports operations such as managing vehicles, users, and rentals.

-The application is built with a layered architecture and demonstrates clean separation of concerns, transaction management, and socket-based communication.



  **Architecture**:


The system is divided into multiple layers:


1.  **Client Layer (WinForms)**

- User interface built with UserControls

- GUI Controllers handle UI logic

- ClientController coordinates communication


2.  **Communication Layer**

- TCP socket communication

- JSON serialization/deserialization

- Request/Response pattern


3.  **Server Layer**

- ClientHandler handles each connected client

- ServerController coordinates business logic


4.  **Business Logic Layer**

- System Operation (SO) pattern

- BaseSO implements template method for transactions

- Concrete SO classes execute specific operations


5.  **Data Access Layer**

- GenericDbRepository for CRUD operations
- IEntity interface for mapping entities to database
- SQL Server database



**Features**

  
- Custom TCP socket communication
- JSON-based message exchange
- Generic repository pattern
- System Operation pattern (transaction management)
- Dependency Injection 
- Multi-client support (thread per client)
- Automatic transaction handling (commit/rollback)
- Connection pooling via SQL Server


**Database Configuration**


-Connection string is defined in server App.config:
<connectionStrings> <add name="RentACar" connectionString="Server=localdb;Database=RentACar;Trusted_Connection=True;" providerName="System.Data.SqlClient" /> </connectionStrings>



**How it works:**

1) Client sends a Request via TCP socket
2) Server receives request in ClientHandler
3) ServerController selects appropriate System Operation
4) BaseSO manages transaction lifecycle
5) GenericDbRepository executes SQL queries
6) Server returns Response back to client


**Design decisions**


- No Singleton pattern used
- All dependencies created in Program.cs (Composition Root)
- Each request uses a new DB connection
- Concurrency handled via threads and database connection pooling
- Concurent testing, mock can be used becouse of DI + no singleton


**Technologies**


C# (.NET 4.7.2 Framework)
WinForms
SQL Server
TCP Sockets
JSON Serialization


**Future Improvements**


-Implement automated testing for services
-Async socket handling
-REST API version
