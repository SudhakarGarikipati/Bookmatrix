-- Seed Data
-- Authors

INSERT INTO Authors (FirstName, LastName, Biography)
VALUES
('George', 'Orwell', 'Author of 1984 and Animal Farm'),
('J.K.', 'Rowling', 'Author of Harry Potter series'),
('Harper', 'Lee', 'Author of To Kill a Mockingbird');

-- Categories

INSERT INTO Categories (CategoryName, Description)
VALUES
('Fiction', 'General fiction books'),
('Science Fiction', 'Sci-fi and futuristic books'),
('Children', 'Books for children'),
('Classic', 'Classic literature');

-- Books
INSERT INTO Books (Title, ISBN, Publisher, PublishedYear, CategoryId, TotalCopies, AvailableCopies)
VALUES
('1984', '9780451524935', 'Secker & Warburg', 1949, 2, 5, 5),
('Harry Potter and the Sorcerer''s Stone', '9780439708180', 'Bloomsbury', 1997, 3, 10, 10),
('To Kill a Mockingbird', '9780061120084', 'J.B. Lippincott & Co.', 1960, 4, 4, 4);

-- BookAuthors
INSERT INTO BookAuthors (BookId, AuthorId)
VALUES
(1, 1), -- 1984 by George Orwell
(2, 2), -- Harry Potter by J.K. Rowling
(3, 3); -- To Kill a Mockingbird by Harper Lee

-- Members
INSERT INTO Members (FullName, Email, Phone, Address)
VALUES
('John Doe', 'john@example.com', '1234567890', '123 Main St'),
('Alice Smith', 'alice@example.com', '9876543210', '456 Park Ave');

-- Loans

INSERT INTO Loans (MemberId, BookId, LoanDate, DueDate, Status)
VALUES
(1, 1, GETDATE(), DATEADD(DAY, 14, GETDATE()), 'Borrowed'),
(2, 2, GETDATE(), DATEADD(DAY, 14, GETDATE()), 'Borrowed');

SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description]) VALUES (1, N'Admin', N'Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description]) VALUES (2, N'Jobseeker', N'Jobseeker')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description]) VALUES (3, N'Employer', N'Employer')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (1, N'Admin', N'Kumar', N'admin@gmail.com', N'9876543210', N'$2a$11$f1jvhcWCRJOh58UktaKCFuFcNzVa9ZEzTQhjdRRMje9DwplWtGZpe', CAST(N'2024-08-29T11:43:19.500' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (2, N'Jobseeker', N'Kumar', N'jobseeker@gmail.com', N'9876543211', N'$2a$11$f6Psc4ksmU5LfLPG53yZLOn7FbOBXBGdcvBiH9bU65Xo.BmLcSASm', CAST(N'2024-08-29T13:01:42.253' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (3, N'Employer', N'Kumar', N'employer@gmail.com', N'9876543210', N'$2a$11$gn78kIqTx4A2i3kiPTac9.QCn57qEDQtlg7rwyw.LKYRht/2ZLY0W', CAST(N'2024-12-25T18:22:35.353' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (4, N'sudhakar', N'garikipati', N'sudhakar@gmail.com', N'+12142879851', N'$2a$11$MsvXlRPK1tCxksV7zmFlN.JuTcrqmnOuYxaE6l3l8hhN253LC5FhO', CAST(N'2026-02-17T09:52:24.750' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (3, 3)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (4, 1)
GO

