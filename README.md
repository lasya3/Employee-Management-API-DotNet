# Employee Management REST API

A backend REST API built using C#, ASP.NET Core (.NET 10), Entity Framework Core, and SQLite to manage employee records.

## Features

- Add new employees
- Retrieve all employees or search by employee ID
- Update employee information
- Delete employee records
- Store employee information persistently using SQLite
- Return appropriate HTTP responses for successful operations and missing records

## Tech Stack

- **Language:** C#
- **Framework:** ASP.NET Core (.NET 10)
- **ORM:** Entity Framework Core
- **Database:** SQLite
- **API Architecture:** REST with Minimal APIs
- **Version Control:** Git and GitHub

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/employees` | Retrieve all employees |
| GET | `/employees/{id}` | Retrieve an employee by ID |
| POST | `/employees` | Add a new employee |
| PUT | `/employees/{id}` | Update employee information |
| DELETE | `/employees/{id}` | Delete an employee |

## How to Run

1. Clone the repository.
2. Make sure the .NET 10 SDK is installed.
3. Open the project directory in a terminal.
4. Run `dotnet restore`.
5. Run `dotnet run`.
6. Use the localhost address displayed in the terminal to test the endpoints.

The SQLite database is created automatically when the application starts.

## Example Request

**POST `/employees`**

```json
{
  "id": 1,
  "name": "Lasya",
  "role": "AI Engineer"
}
```

## What I Learned

This project helped me gain hands-on experience with C#, ASP.NET Core Minimal APIs, RESTful CRUD operations, Entity Framework Core, database persistence, and Git version control.
