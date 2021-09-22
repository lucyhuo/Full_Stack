
-- 1. Lock tables Region, Territories, EmployeeTerritories and Employees. Insert following information into the database. In case of an error, no changes should be made to DB.
-- A new region called “Middle Earth”;
-- A new territory called “Gondor”, belongs to region “Middle Earth”;
-- A new employee “Aragorn King” who's territory is “Gondor”.
BEGIN TRAN 
INSERT INTO Region VALUES (5, 'Middle Earth')
INSERT INTO Territories VALUES (00001, 'Gondor', 5)
INSERT INTO Employees (LastName, FirstName) VALUES ('King', 'Aragorn')
INSERT INTO EmployeeTerritories VALUES (10, 00001)

-- 2. Change territory “Gondor” to “Arnor”.
UPDATE Territories 
SET TerritoryDescription = 'Arnor'
WHERE TerritoryID = 1

-- 3. Delete Region “Middle Earth”. (tip: remove referenced data first) (Caution: do not forget WHERE or you will delete everything.) In case of an error, no changes should be made to DB. Unlock the tables mentioned in question 1.
DELETE FROM EmployeeTerritories WHERE TerritoryID = 1
DELETE FROM Territories WHERE RegionID = 5
DELETE FROM Region WHERE RegionID = 5

COMMIT 

GO 
-- 4. Create a view named “view_product_order_[your_last_name]”, list all products 
-- and total ordered quantity for that product.

CREATE VIEW view_product_order_huo AS 

SELECT p.ProductName, sum(od.Quantity) as Total
FROM Products p 
LEFT JOIN [Order Details] od on od.ProductID = p.ProductID
GROUP BY p.ProductName
GO 



-- 5. Create a stored procedure “sp_product_order_quantity_[your_last_name]” 
-- that accept product id as an input and total quantities of order as output parameter.

CREATE PROC sp_product_order_quantity_huo 
@pid int, @quantities int output
AS 
SElECT @quantities = Total
FROM 
(
SELECT p.ProductName, sum(od.Quantity) as Total
FROM Products p 
LEFT JOIN [Order Details] od on od.ProductID = p.ProductID
WHERE p.ProductID = @pid 
GROUP BY p.ProductName
) t
GO 

declare @totalQuantity bigint 
EXEC sp_product_order_quantity_huo 2, @totalQuantity out
print @totalQuantity
GO 

-- 6. Create a stored procedure “sp_product_order_city_[your_last_name]” 
-- that accept product name as an input 
-- and top 5 cities that ordered most that product 
-- combined with the total quantity of that product ordered from that city as output.

CREATE PROC sp_product_order_city_huo 
@pName varchar(20) 
AS
SELECT TOP 5 o.ShipCity, sum(od.Quantity) as quantity
FROM Orders o 
INNER JOIN [Order Details] od on o.OrderID = od.OrderID
INNER JOIN Products p on od.ProductID = p.ProductID
WHERE p.ProductName = @pName
GROUP BY o.ShipCity
ORDER BY quantity desc
GO 

sp_product_order_city_huo 'Chai'
GO 

SELECT * FROM Region
SELECT * FROM Territories
SELECT * FROM EmployeeTerritories
SELECT * FROM Employees
GO 
/* 
-- 7. 
Lock tables Region, Territories, EmployeeTerritories and Employees. 
Create a stored procedure “sp_move_employees_[your_last_name]” 
that automatically find all employees in territory “Tory”; 
if more than 0 found, insert a new territory “Stevens Point” of region “North” to the database, 
and then move those employees to “Stevens Point”.
*/ 

CREATE PROC sp_move_employees_huo 
@cnt int output 
AS 
IF EXISTS (
SELECT et.EmployeeID
FROM EmployeeTerritories et 
LEFT JOIN Territories t on t.TerritoryID = et.TerritoryID
WHERE t.TerritoryDescription = 'Tory'
) 
BEGIN 
	INSERT INTO Region VALUES (5, 'North') 
	INSERT INTO Territories VALUES ('00001', 'Stevens Point', 5)
	UPDATE EmployeeTerritories SET TerritoryID = '00001' WHERE EmployeeID in 
	(SELECT et.EmployeeID
	FROM EmployeeTerritories et 
	LEFT JOIN Territories t on t.TerritoryID = et.TerritoryID
	WHERE t.TerritoryDescription = 'Tory')

END
GO 
-- 8. Create a trigger that when there are more than 100 employees in territory “Stevens Point”, 
-- move them back to Troy. (After test your code,) remove the trigger. 
-- Move those employees back to “Troy”, if any. Unlock the tables.

/* 
-- 9. 
Create 2 new tables “people_your_last_name” “city_your_last_name”. 
City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, 
{Id: 3, Name: Jody Nelson, City:2}. Remove city of Seattle. 
If there was anyone from Seattle, put them into a new city “Madison”. 
Create a view “Packers_your_name” lists all people from 2Green Bay. 
If any error occurred, no changes should be made to DB. (after test) Drop both tables and view.
*/ 

CREATE TABLE city_huo (ID int identity(1,1) primary key, City varchar(10) not null)
GO 
CREATE TABLE people_huo (ID int identity(1,1) primary key, Name varchar(20) not null, 
CityID int not null foreign key references city_huo(ID))
GO 

INSERT INTO city_huo VALUES ('Seattle') 
INSERT INTO city_huo VALUES ('Green Bay') 
INSERT INTO city_huo VALUES ('Madison') 
INSERT INTO people_huo VALUES ('Aaron Rodgers', 2)
INSERT INTO people_huo VALUES ('Russell Wilson', 1)
INSERT INTO people_huo VALUES ('Jody Nelson', 2)
GO 

UPDATE people_huo SET CityID = 3 WHERE CityID = 1
GO 

CREATE VIEW Packer_huo AS 
SELECT * FROM people_huo WHERE CityID = 2
GO 

DROP TABLE people_huo
DROP TABLE city_huo
DROP VIEW Packer_huo

-- 10.  Create a stored procedure “sp_birthday_employees_[you_last_name]” 
-- that creates a new table “birthday_employees_[your_last_name]” 
-- and fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. 
-- Employee table should not be affected.

CREATE PROC sp_birthday_employees_huo 
AS 
CREATE TABLE birthday_employees_huo 
(EmployeeID int primary key,
LastName nvarchar(20) not null, 
FirstName nvarchar(10) not null, 
BirthDate datetime null
)
SELECT e.EmployeeID, e.LastName, e.FirstName, e.BirthDate
FROM Employees e 
WHERE month(BirthDate) = 2 
DROP TABLE birthday_employees_huo 
GO 

sp_birthday_employees_huo
GO 




-- 11. Create a stored procedure named “sp_your_last_name_1” 
-- that returns all cites that have at least 2 customers 
-- who have bought no or only one kind of product. 
-- Create a stored procedure named “sp_your_last_name_2” 
-- that returns the same but using a different approach. (sub-query and no-sub-query).

CREATE PROC sp_huo_1 
AS 
SELECT City, count(CustomerID) as customers
FROM 
(
SELECT c.City, c.CustomerID ,count(distinct od.ProductID) as ProductKind
FROM 
Customers c 
LEFT JOIN Orders o on o.CustomerID = c.CustomerID
LEFT JOIN 
[Order Details] od on o.OrderID = od.OrderID
GROUP BY c.City, c.CustomerID
HAVING count(distinct od.ProductID) < 2
) t 
GROUP BY City
HAVING count(CustomerID) > 2
GO 

sp_huo_1
GO 

-- 14. 
/*
SELECT concat(e.FirstName, ' ', e.LastName, ' ', 
case when e.MiddleName is not null then concat(e.MiddleName, '.') 
end )
FROM Employees e
*/ 

-- 15. 
/* 
Select * 
From 
(
SELECT Student, Marks,
dense_rank() over (partition by Sex order by Marks desc) as rk 
FROM tmp 
WHERE Sex = 'F'
) t 
Where rk = 1 
*/ 



-- 16. 

