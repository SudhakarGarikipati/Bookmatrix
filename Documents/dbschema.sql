--Database Creation
CREATE DATABASE bookmatrixdb;
GO

USE bookmatrixdb;
GO

--Table creation
-- Authors
CREATE TABLE Authors (
    AuthorId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Biography NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Categories
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(200) NOT NULL UNIQUE,
    Description NVARCHAR(MAX) NULL
);

-- Books
CREATE TABLE Books (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(300) NOT NULL,
    ISBN NVARCHAR(20) UNIQUE NOT NULL,
    Publisher NVARCHAR(200),
    PublishedYear INT,
    CategoryId INT NOT NULL,
    TotalCopies INT NOT NULL DEFAULT 1,
    AvailableCopies INT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_Books_Categories 
        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

--Book Authors
CREATE TABLE BookAuthors (
    BookId INT NOT NULL,
    AuthorId INT NOT NULL,

    PRIMARY KEY (BookId, AuthorId),

    CONSTRAINT FK_BookAuthors_Books 
        FOREIGN KEY (BookId) REFERENCES Books(BookId),

    CONSTRAINT FK_BookAuthors_Authors 
        FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId)
);

-- Members
CREATE TABLE Members (
    MemberId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) UNIQUE NOT NULL,
    Phone NVARCHAR(20),
    Address NVARCHAR(500),
    MembershipDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1
);

--Loans (Book Borrowing)
CREATE TABLE Loans (
    LoanId INT IDENTITY(1,1) PRIMARY KEY,
    MemberId INT NOT NULL,
    BookId INT NOT NULL,
    LoanDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    DueDate DATETIME2 NOT NULL,
    ReturnDate DATETIME2 NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Borrowed', -- Borrowed, Returned, Late

    CONSTRAINT FK_Loans_Members 
        FOREIGN KEY (MemberId) REFERENCES Members(MemberId),

    CONSTRAINT FK_Loans_Books 
        FOREIGN KEY (BookId) REFERENCES Books(BookId)
);

-- Librarians (Optional admin users)
CREATE TABLE Librarians (
    LibrarianId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(200) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(500) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Useful indexes
CREATE INDEX IX_Books_CategoryId ON Books(CategoryId);
CREATE INDEX IX_Loans_MemberId ON Loans(MemberId);
CREATE INDEX IX_Loans_BookId ON Loans(BookId);
CREATE INDEX IX_Members_Email ON Members(Email); 