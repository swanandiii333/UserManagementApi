# User Management API

This is a basic RESTful Web API written in ASP.NET Core and C# that allows users to be managed using CRUD operations. Input validation has been implemented along with request logging middleware and a Swagger interface.

## Features

- Create a new user
- Get all users or a specific user
- Update user details
- Delete a user
- Data annotations used to validate user input
- Custom middleware to log request data (HTTP methods and paths)
- Swagger interface to test endpoints

## Technologies

- C#
- ASP.NET Core Web API
- .NET 10
- Swagger/OpenAPI
- Data annotations
- Git and GitHub

## File Structure

```text
UserManagementApi/
├── Controllers/
│   └── WeatherForecastController.cs
├── Models/
│   └── User.cs
├── Properties/
│   └── launchSettings.json
├── Program.cs
├── UsersController.cs
├── UserManagementApi.csproj
├── appsettings.json
└── appsettings.Development.json
```

## Requirements

- .NET 10 SDK
- Code editor (e.g., Visual Studio Code)
- Web browser

## Running the Project

1. Clone the repository:

```bash
git clone https://github.com/swanandiii333/UserManagementApi.git
```

2. Navigate to the application folder:

```bash
cd UserManagementApi/UserManagementApi
```

3. Restore dependencies and build the project:

```bash
dotnet build
```

4. Start the API:

```bash
dotnet run --urls http://0.0.0.0:5000
```

5. Visit the Swagger interface:

```text
http://localhost:5000/swagger
```

If using GitHub Codespaces, visit the forwarded port 5000 link and append `/swagger` to the end.

## API Endpoints

The base route is `/api/Users`.

| HTTP Method | Endpoint | Description | Success Status Code |
|---|---|---|---|
| GET | `/api/Users` | Get all users | 200 OK |
| GET | `/api/Users/{id}` | Get user by ID | 200 OK |
| POST | `/api/Users` | Create a new user | 201 Created |
| PUT | `/api/Users/{id}` | Update user | 204 No Content |
| DELETE | `/api/Users/{id}` | Delete user | 204 No Content |

If a user is not found with the requested ID, the API returns `404 Not Found`.

## Example User Request

To create a user, send a POST request to `/api/Users` with the following JSON:

```json
{
  "name": "Swanandi Test",
  "email": "swanandi.test@example.com",
  "age": 20
}
```

The ID will be automatically assigned by the server.

## Input Validation

Data annotations have been used in the User model to validate the input.

- Name is required and must be between 2 and 100 characters.
- Email is required and must be in a valid email format.
- Age must be between 18 and 100.

The `[ApiController]` attribute has been added to the controller. This automatically returns a `400 Bad Request` response if the model fails validation.

For example, if an invalid email is sent, the request will fail with a validation error.

## Request Logging Middleware

Custom middleware has been implemented in `Program.cs` to log the HTTP methods and paths being requested.

Example output:

```text
Request: GET /api/Users
Request: POST /api/Users
Request: GET /api/Users/1
```

This demonstrates how middleware can be used to inspect the requests being made.

## In-Memory List

This project uses an in-memory list instead of a database.

Any users created, updated, or deleted will only be stored while the application is running. Once the application is restarted, the data will be reset and will not be shared between different instances of the application.

In a future version, a database such as SQL Server, PostgreSQL, or SQLite could be added.

## Testing

The endpoints were tested using the Swagger interface.

- A user was created, and the `201 Created` response was verified.
- All users and a specific user were retrieved.
- A user was updated, and the `204 No Content` response was verified.
- A user was deleted, and a subsequent GET request was confirmed to return `404 Not Found`.
- Invalid email data was sent, and the `400 Bad Request` response was verified.
- The terminal output was checked to confirm that the request logging middleware was working.

## GitHub Repository

https://github.com/swanandiii333/UserManagementApi

## Future Improvements

- Add a database for persistent storage.
- Ensure email addresses are unique if needed.
- Add unit and integration tests.
- Enhance request logging to include status codes and execution time.
- Add authentication and authorization if needed.

## License

This project was created for educational purposes.