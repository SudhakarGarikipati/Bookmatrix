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
