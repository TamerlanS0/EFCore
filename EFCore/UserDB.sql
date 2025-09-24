CREATE DATABASE UserDB;
GO

USE UserDB;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Age INT,
    Gender BIT
);

INSERT INTO Users (UserName, Password, FirstName, LastName, Age, Gender)
VALUES ('admin', '1234', 'Admin', 'User', 25, 1);
