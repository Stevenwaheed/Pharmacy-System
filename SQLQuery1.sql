CREATE TABLE Terms
(
    ID int identity(1, 1),
    Name nvarchar(100),
    Price decimal(2),
    Quantity int, 
    Date nvarchar(100)
)
CREATE TABLE Receipt
(
    ID int identity(1, 1),
    Name nvarchar(100),
    Price decimal(2),
    Quantity int, 
    Box nvarchar(20),
    Total decimal(2)
)
CREATE TABLE Bank
(
    ID int identity(1, 1),
    Name nvarchar(100),
    Price decimal(2),
    Date nvarchar(100)
)