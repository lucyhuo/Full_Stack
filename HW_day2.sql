/*
-- Answer following questions

1. What is a result set? 
- the output of a query.
2. What is the difference between Union and Union All? 
- both concatenate the result sets from two or more SELECT statement, UNION only result in unique values, but UNION ALL allows duplicates 
3. What are the other Set Operators SQL Server has? 
- intersect, except
- intersect: returns distinct values from both result sets which are in common. 
- except: like minus, returns distinct values from the first result set but those are not returned in the second query.
4. What is the difference between Union and Join?
- union: append two result sets from the queries, the result sets must have same columns
- join: merge records, retrieve data from tables or views and merge columns from them based on the condition in where statement 
5. What is the difference between INNER JOIN and FULL JOIN?
- inner join: fetch data from left and right table which satisfy the join condition
- full join: return all rows in both the left and the right table. Anytime a row has no match from the other table, the selected columns from the other table contain NULL value. Whenever there is a match between the tables, the entire result set row contains data values from the base tables. 
6. What is difference between left join and outer join
- outer join has3 different join types, left join, right join, and full join 
- left join is one type of outer join 
7. What is cross join?
- returns Cartesian product of the set of records from two joined tables. It equals an inner join where the join condition always evaluates to TRUE. 
8. What is the difference between WHERE clause and HAVING clause?
- WHERE behind FROM statement; HAVING befind GROUP BY statement
- WHERE select/qualify rows that are returned before the data is grouped; HAVING qualify rows that are returned after the data is aggregated
- HAVING allows you to specify a search condition on a query using GROUP BY and/ or an aggregated value
9. Can there be multiple group by columns?
- yes. the system will group the data by the combination of the multiple columns. It means put all those with the same values for both X and Y in the one group.

*/


-- Write queries for following scenarios

-- 1. How many products can you find in the Production.Product table?

SELECT COUNT(p.ProductID) AS CntProduct
FROM Production.Product p

-- 2. Write a query that retrieves the number of products in the Production.Product table 
-- that are included in a subcategory. 
-- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(p.ProductID) AS CntProductInSubcat
FROM Production.Product p
WHERE p.ProductSubcategoryID is not null 

/*
-- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
ProductSubcategoryID CountedProducts
-------------------- ---------------
*/ 

SELECT p.ProductSubcategoryID, COUNT(p.ProductID) AS CountedProducts
FROM Production.Product p
WHERE p.ProductSubcategoryID is not null 
GROUP BY p.ProductSubcategoryID


-- 4. How many products that do not have a product subcategory. 
SELECT COUNT(p.ProductID) AS CntProductInSubcat
FROM Production.Product p
WHERE p.ProductSubcategoryID is  null 

-- 5. Write a query to list the summary of products quantity in the Production.ProductInventory table.
SELECT SUM(pin.Quantity) AS TheSum
FROM Production.ProductInventory pin 


/*
-- 6. Write a query to list the summary of products in the Production.ProductInventory table 
-- and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
              ProductID    TheSum
-----------        ----------
*/ 

SELECT pin.ProductID ,SUM(pin.Quantity) AS TheSum
FROM Production.ProductInventory pin 
WHERE pin.LocationID = 40
GROUP BY pin.ProductID
HAVING SUM(pin.Quantity) < 100 



/* 
-- 7. Write a query to list the summary of products with the shelf information in the Production.ProductInventory
-- table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
Shelf      ProductID    TheSum
---------- -----------        -----------
*/ 

SELECT pin.Shelf , pin.ProductID ,SUM(pin.Quantity) AS TheSum
FROM Production.ProductInventory pin 
WHERE pin.LocationID = 40
GROUP BY pin.Shelf, pin.ProductID
HAVING SUM(pin.Quantity) < 100 


-- 8. Write the query to list the average quantity for products where column LocationID 
-- has the value of 10 from the table Production.ProductInventory table.

SELECT AVG(pin.Quantity) AS TheAvg
FROM Production.ProductInventory pin 
WHERE pin.LocationID = 10


/*
-- 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
ProductID   Shelf      TheAvg
----------- ---------- -----------
*/ 

SELECT pin.ProductID, pin.Shelf , AVG(pin.Quantity) AS TheAvg
FROM Production.ProductInventory pin 
GROUP BY pin.ProductID, pin.Shelf

/*
-- 10. Write query  to see the average quantity  of  products by shelf excluding rows 
-- that has the value of N/A in the column Shelf from the table Production.ProductInventory
ProductID   Shelf      TheAvg
----------- ---------- -----------
*/ 

SELECT pin.ProductID, pin.Shelf , AVG(pin.Quantity) AS TheAvg
FROM Production.ProductInventory pin 
WHERE pin.Shelf <> 'N/A'
GROUP BY pin.ProductID, pin.Shelf


/*
11. List the members (rows) and average list price in the Production.Product table. 
This should be grouped independently over the Color and the Class column. 
Exclude the rows where Color or Class are null.

Color           	Class 	TheCount   	 AvgPrice
--------------	- ----- 	----------- 	---------------------
*/ 

SELECT p.Color, p.Class, COUNT(p.ProductID) as TheCount, AVG(p.ListPrice) as AvgPrice
FROM Production.Product p
WHERE p.Color is not null 
	AND p.Class is not null 
GROUP BY p.Color, p.Class


/* 
12. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. 
Join them and produce a result set similar to the following. 

Country                        Province
---------                          ----------------------
*/ 

SELECT cr.Name AS Country, sp.Name AS Province
FROM Person.CountryRegion cr
LEFT JOIN Person.StateProvince sp 
ON cr.CountryRegionCode = sp.CountryRegionCode


/*
13. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables 
and list the countries filter them by Germany and Canada. 
Join them and produce a result set similar to the following.

Country                        Province
---------                          ----------------------
*/ 

SELECT cr.Name AS Country, sp.Name AS Province
FROM Person.CountryRegion cr
LEFT JOIN Person.StateProvince sp 
ON cr.CountryRegionCode = sp.CountryRegionCode
WHERE cr.Name in ('Canada', 'Germany')


/*
USE NORTHWND databases
*/



-- 14. List all Products that has been sold at least once in last 25 years.

SELECT DISTINCT p.ProductName
FROM Orders o
LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
LEFT JOIN Products p ON od.ProductID = p.ProductID
WHERE 2021 - year(o.OrderDate) < 25


-- 15. List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 o.ShipPostalCode , sum(od.Quantity) as Quatity
FROM Orders o
LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE o.ShipPostalCode is not null
GROUP BY o.ShipPostalCode
ORDER BY Quatity DESC


-- 16. List top 5 locations (Zip Code) where the products sold most in last 20 years.

SELECT TOP 5 o.ShipPostalCode ,  sum(od.Quantity) as Quatity
FROM Orders o
LEFT JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE 2021 - year(o.OrderDate) < 20 -- this will result empty result set 
	and o.ShipPostalCode is not null
GROUP BY o.ShipPostalCode
ORDER BY Quatity DESC


-- 17. List all city names and number of customers in that city.     
SELECT c.City, count(c.customerid) as CntCustomers
FROM Customers c
GROUP BY c.City


-- 18. List city names which have more than 10 customers, and number of customers in that city 

SELECT c.City, count(c.customerid) as CntCustomers
FROM Customers c
GROUP BY c.City
HAVING count(c.customerid) >10 -- empty result set 

-- 19. List the names of customers who placed orders after 1/1/98 with order date.

SELECT DISTINCT c.ContactName
FROM Customers c
LEFT JOIN Orders o on o.CustomerID = c.CustomerID
WHERE o.OrderDate > DATEFROMPARTS(1998, 1, 1)


-- 20. List the names of all customers with most recent order dates 

SELECT c.ContactName, max( o.OrderDate) as LatestOrderDate
FROM Customers c 
LEFT JOIN  Orders o on o.CustomerID = c.CustomerID
GROUP BY c.ContactName


-- 21. Display the names of all customers  along with the  count of products they bought 

SELECT c.ContactName, count(od.ProductID) as CntProduct
FROM Customers c 
LEFT JOIN  Orders o on o.CustomerID = c.CustomerID
LEFT JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName


-- 22. Display the customer ids who bought more than 100 Products with count of products.

SELECT c.ContactName, count(od.ProductID) as CntProduct
FROM Customers c 
LEFT JOIN  Orders o on o.CustomerID = c.CustomerID
LEFT JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName
HAVING count(od.ProductID) > 100

/*
-- 23. List all of the possible ways that suppliers can ship their products. 
Display the results as below

Supplier Company Name   	Shipping Company Name
---------------------------------            ----------------------------------
*/

SELECT s.CompanyName AS 'Supplier Company Name', sh.CompanyName AS 'Shipping Company Name'
FROM Suppliers s
CROSS JOIN Shippers sh

-- 24. Display the products order each day. Show Order date and Product Name.

SELECT  o.OrderDate, o.OrderID, p.ProductName
FROM Orders o 
LEFT JOIN [Order Details] od ON od.OrderID = o.OrderID
LEFT JOIN Products p ON od.ProductID = p.ProductID


-- 25. Displays pairs of employees who have the same job title.

SELECT e1.FirstName, e1.LastName, e2. FirstName, e2. LastName
FROM Employees e1 
LEFT JOIN Employees e2 on e1.Title = e2.Title
WHERE CONCAT(e1.FirstName, e1.LastName) <>  CONCAT( e2. FirstName, e2. LastName)

-- 26. Display all the Managers who have more than 2 employees reporting to them.

SELECT m.EmployeeID, m.FirstName, m.LastName, count(e.EmployeeID) as Cnt
FROM Employees m
LEFT JOIN Employees e on m.EmployeeID = e.ReportsTo
GROUP BY m.EmployeeID, m.FirstName, m.LastName
HAVING count(e.EmployeeID) > 2


/*
27. 
Display the customers and suppliers by city. The results should have the following columns
City 
Company Name 
Contact Name,
Type (Customer or Supplier)
*/ 

SELECT City, CompanyName, ContactName, 'Customer' as Type
FROM Customers c 
UNION
SELECT City, CompanyName, ContactName, 'Supplier' as Type
FROM Suppliers s

/*
28.
 Have two tables T1 and T2

Please write a query to inner join these two tables and write down the result of this query.
*/ 

SELECT T1.F1, T2.F2
FROM T1 
INNER JOIN T2 
ON F1 = F2 

/*
28 result 
F1.T1	F2.T2
2		2
3		3
*/


/*
29.
Based on above two table, Please write a query to left outer join these two tables 
and write down the result of this query.
*/

SELECT T1.F1, T2.F2
FROM T1 
LEFT JOIN T2 
ON F1 = F2 

/*
29 result 
F1.T1	F2.T2
1		NULL
2		2
3		3
*/
