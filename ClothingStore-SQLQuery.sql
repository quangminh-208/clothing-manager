CREATE TABLE Clothing (
  ClothingId INT PRIMARY KEY AUTO_INCREMENT,
  ClothingName VARCHAR(255) NOT NULL,
  Size VARCHAR(50),
  Color VARCHAR(50),
  Brand VARCHAR(255),
  Price DECIMAL(10,2) NOT NULL
);

CREATE TABLE User (
  UserId INT PRIMARY KEY AUTO_INCREMENT,
  FirstName VARCHAR(255) NOT NULL,
  LastName VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NOT NULL UNIQUE,
  PhoneNumber VARCHAR(20)
);

CREATE TABLE UserOrder (
  OrderId INT PRIMARY KEY AUTO_INCREMENT,
  UserId INT NOT NULL,
  OrderDate DATETIME NOT NULL,
  OrderStatus VARCHAR(50) DEFAULT 'placed',
  FOREIGN KEY (UserId) REFERENCES User(UserId)
);

CREATE TABLE OrderItem (
  OrderItemId INT PRIMARY KEY AUTO_INCREMENT,
  OrderId INT NOT NULL,
  ClothingId INT NOT NULL,
  Quantity INT NOT NULL,
  FOREIGN KEY (OrderId) REFERENCES UserOrder(OrderId),
  FOREIGN KEY (ClothingId) REFERENCES Clothing(ClothingId)
);



INSERT INTO Clothing (ClothingName, Size, Color, Brand, Price)
VALUES ('T-Shirt', 'M', 'Blue', 'Brand X', 19.99),
       ('Dress Shirt', 'L', 'White', 'Brand Y', 29.95),
       ('Jeans', '32W x 30L', 'Indigo', 'Brand Z', 49.99),
       ('Sweatshirt', 'S', 'Gray', 'Brand X', 34.99),
       ('Sweater', 'M', 'Black', 'Brand Y', 25.50);

INSERT INTO User (FirstName, LastName, Email, PhoneNumber)
VALUES ('John', 'Doe', 'john.doe@Email.com', '123-456-7890'),
       ('Jane', 'Smith', 'jane.smith@Email.com', '555-123-4567');


-- Retrieve the IDs of the recently inserted Users (assuming John Doe's ID is 1)
SELECT UserId FROM User WHERE FirstName = 'John';

-- Use the retrieved ID to create orders
INSERT INTO UserOrder (UserId, OrderDate)
VALUES (1, NOW()),  -- Replace 1 with the actual User ID for John Doe
       (2, NOW());  -- Assuming Jane Smith has ID 2 (replace accordingly)

-- Retrieve the IDs of the recently inserted clothing items (assuming first T-Shirt has ID 1)
SELECT ClothingId FROM Clothing WHERE ClothingName = 'T-Shirt';

-- Retrieve the IDs of the recently inserted orders (assuming John Doe's order has ID 1)
SELECT OrderId FROM UserOrder WHERE UserId = 1;  -- Replace 1 with John Doe's ID

-- Use the retrieved IDs to create order items
INSERT INTO OrderItem (OrderId, ClothingId, Quantity)
VALUES (1, 1, 2),  -- John Doe's order (ID 1), T-Shirt (ID 1), Quantity 2
       (1, 3, 1),  -- John Doe's order, Jeans (ID 3), Quantity 1
       (2, 2, 1),  -- Jane Smith's order, Dress Shirt (ID 2), Quantity 1
       (2, 4, 3),  -- Jane Smith's order, Sweatshirt (ID 4), Quantity 3
       (2, 5, 2);  -- Jane Smith's order, Sweater (ID 5), Quantity 2
       


