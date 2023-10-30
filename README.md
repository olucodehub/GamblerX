# GamblerX

# To Do
# 1. Implement role based authorization on the Betting Controller to ensure for ex: Only admin users can add/update a Betting 
# End To Do

App following clean architecture and DDD principles.

Clone and Restore nugget package with command "dotnet restore"

Build the project

Run the API project with command "dotnet run --project .\GamblerX.API\"

Register a new user with a Post request, Ex: http://localhost:5221/auth/register

{
"firstname": "Olu",
"lastname": "Bunmi",
"email": "olubunmi@example.com",
"password": "password"
}

// Error handler 1, 2 ,3 as defined in program.cs and other are the three methods of handling errors globally

I am using "Error handler 2" currently and ensured I uncomment everywhere in the solution where i labelled "Error handler 2"

I prefer "Error handler 2" because I can define various roperties of the ProblemDetails object as seen in ErrorHandlingFilterAttribute.cs
