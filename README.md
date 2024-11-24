# Wallet App Backend

This repository contains the backend implementation for the Wallet App, built using .NET 7 and adhering to Clean Architecture principles. The project incorporates CQRS with MediatR, a background service for computing daily points, and a RESTful API with Swagger for easy testing.

## **Features**
- **Clean Architecture**: Promotes separation of concerns and scalable design.
- **CQRS with MediatR**: Simplifies command and query handling for the application.
- **Daily Points Computation**: A background service calculates daily user points based on seasonal rules.
- **PostgreSQL Database**: Fully integrated with Entity Framework Core and migrations.
- **Swagger UI**: Facilitates testing and exploring RESTful APIs.
- **Null Safety**: Enabled in C# 11 for robust code.

---

## **Project Requirements**
- .NET 7.0
- PostgreSQL
- Entity Framework Core
- Swagger

---

## **Installation**

1. Clone the repository:
    ```bash
    git clone https://github.com/semirhamid/WalletAppBackend.git
    ```
2. Navigate to the project directory:
    ```bash
    cd WalletAppBackend
    ```
3. Configure the database connection string in `appsettings.json`.

4. Apply the migrations to set up the database:
    ```bash
    dotnet ef database update
    ```

5. Run the project:
    ```bash
    dotnet run
    ```

6. Access the Swagger UI at `http://localhost:44357/swagger`.

---

## **API Endpoints**

### Transactions
- **GET** `/api/transactions`  
  Retrieves a list of the latest transactions.

- **GET** `/api/transactions/{id}`  
  Retrieves details of a specific transaction.

### Points
- **GET** `/api/daily-points`  
  Retrieves the points for the current day.

---

## **Background Service**

A background service computes daily points based on the following rules:
1. **First Day of Season**: 2 points.
2. **Second Day of Season**: 3 points.
3. **Subsequent Days**: 60% of the previous day's points plus 100% of the points from the season's first day.

---

## **Technologies Used**
- **.NET 7.0**: For backend development.
- **PostgreSQL**: Database management.
- **Entity Framework Core**: ORM with migrations.
- **Swagger**: API documentation and testing.
- **MediatR**: Simplifies CQRS implementation.

---

## **Contributing**
Contributions are welcome! Please fork the repository, make changes, and submit a pull request.

---

## **License**
This project is licensed under the MIT License. See `LICENSE` for details.

---

## **Contact**
For any inquiries or support, please contact [Semir Hamid](https://github.com/semirhamid).
