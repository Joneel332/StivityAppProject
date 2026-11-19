-- 1. Create the Database
IF DB_ID('StivityDB') IS NULL
BEGIN
    CREATE DATABASE StivityDB;
END
GO

-- 2. Switch to the Database
USE StivityDB;
GO

-- 3. Create the Tables (Drop them first if they exist to start fresh)
IF OBJECT_ID('Tasks', 'U') IS NOT NULL DROP TABLE Tasks;
IF OBJECT_ID('ClassSchedules', 'U') IS NOT NULL DROP TABLE ClassSchedules;
IF OBJECT_ID('Expenses', 'U') IS NOT NULL DROP TABLE Expenses;
IF OBJECT_ID('Students', 'U') IS NOT NULL DROP TABLE Students;

CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentNumber NVARCHAR(20) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    WeeklyAllowance DECIMAL(10, 2) NOT NULL DEFAULT 0
);

CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    Title NVARCHAR(150) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Priority NVARCHAR(20) NOT NULL,
    DueDate DATE NOT NULL,
    IsCompleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE ClassSchedules (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    SubjectCode NVARCHAR(50) NOT NULL,
    Room NVARCHAR(50) NOT NULL,
    DayOfWeek NVARCHAR(20) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    ReminderMinsBefore INT NOT NULL DEFAULT 15,
    IsShifted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Expenses (
    ExpenseID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    Description NVARCHAR(150) NOT NULL,
    Category NVARCHAR(50) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    ExpenseDate DATETIME NOT NULL DEFAULT GETDATE()
);

INSERT INTO Students (StudentNumber, FullName, PasswordHash, WeeklyAllowance)
VALUES ('543210', 'Jerryme S. Tohoy', 'stivity123', 3000.00);