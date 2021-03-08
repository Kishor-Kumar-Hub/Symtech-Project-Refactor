# Refactoring Assessment

This repository contains a terribly written Web API project. It's terrible on purpose, so you can show us how we can improve it.

## Getting Started

Fork this repository, and make the changes you would want to see if you had to maintain this api. To set up the project:

 - Open in Visual Studio (2015 or later is preferred)
 - Restore the NuGet packages and rebuild
 - Run the project
 
 Once you are satisied, replace the contents of the readme with a summary of what you have changed, and why. If there are more things that could be improved, list them as well.

The api is composed of the following endpoints:

| Verb     | Path                                   | Description
|----------|----------------------------------------|--------------------------------------------------------
| `GET`    | `/api/Accounts`                        | Gets the list of all accounts
| `GET`    | `/api/Accounts/{id:guid}`              | Gets an account by the specified id
| `POST`   | `/api/Accounts`                        | Creates a new account
| `PUT`    | `/api/Accounts/{id:guid}`              | Updates an account
| `DELETE` | `/api/Accounts/{id:guid}`              | Deletes an account
| `GET`    | `/api/Accounts/{id:guid}/Transactions` | Gets the list of transactions for an account
| `POST`   | `/api/Accounts/{id:guid}/Transactions` | Adds a transaction to an account, and updates the amount of money in the account

Models should conform to the following formats:

**Account**
```
{
    "Id": "01234567-89ab-cdef-0123-456789abcdef",
	"Name": "Savings",
	"Number": "012345678901234",
	"Amount": 123.4
}
```	

**Transaction**
```
{
    "Date": "2018-09-01",
    "Amount": -12.3
}
```


//Changes done:

Seperated the entities out to the seperate class library named as core
Seperated the data access logic to DataAccess project and used Entity Framework for data access
Created stored procedure and parameterized queries in order to avoid sql injection attacks

//Mistakes:
Updates the amount of money in the account
No seperation of concerns
Too many SQL connections

Stored Proc:

CREATE PROCEDURE [dbo].[GetTransactionsForAccount]
(@AccountId [uniqueidentifier])
AS
BEGIN
SET NOCOUNT ON
 
SELECT Id, Amount, [Date], AccountId  FROM Transactions
where [AccountId] = @AccountId
 
END
GO


//Todo
--SOLID Policies must be followed
--Dependency injection can be used
--Integration Tests can be included 
--More Exception handlings to be done
--Summary comments can be included
--Api Documentation tool can be used to list the operations performed by this API