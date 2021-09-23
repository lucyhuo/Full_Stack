/* 
1. Write an sql statement that will display the name of each customer 
and the sum of order totals placed by that customer during the year 2002

 Create table customer(cust_id int,  iname varchar (50)) 
 create table order(order_id int,cust_id int,amount money,order_date smalldatetime)
 */ 
SELECT 
c.iname, sum(o.order_id) as total 
FROM customer c 
LEFT JOIN order o on c.cust_id = o.cust_id 
WHERE year(order_date) = 2002 
GROUP BY c.iname





/* 
 2.  The following table is used to store information about company’s personnel:
Create table person (id int, firstname varchar(100), lastname varchar(100)) 
write a query that returns all employees whose last names  start with “A”.
*/ 

SELECT * 
FROM person 
WHERE lastname like 'A%'


/* 
3.  The information about company’s personnel is stored in the following table:
Create table person(person_id int primary key, manager_id int null, name varchar(100)not null) 
The filed managed_id contains the person_id of the employee’s manager.
Please write a query that would return the names of all top managers
(an employee who does not have a manger), and the number of people that report directly to this manager.
*/ 

CREATE TABLE person(person_id int primary key, manager_id int null, name varchar(100)not null) 
GO

INSERT INTO person VALUES (1,null, 'A') 
INSERT INTO person VALUES (2,1, 'B') 
INSERT INTO person VALUES (3,1, 'C') 
INSERT INTO person VALUES (4,null, 'D') 
INSERT INTO person VALUES (5,4, 'E')
INSERT INTO person VALUES (6,null, 'F')


SELECT m.name, dr.totalDR 
FROM 
(
SELECT e.person_id, e.name
FROM person e 
LEFT JOIN person m on e.manager_id = m.person_id 
WHERE m.person_id is null -- top manager 
) m 
left join (
SELECT manager_id, count(person_id) as TotalDR 
FROM person
GROUP BY manager_id
) dr on m.person_id = dr.manager_id 

DROP TABLE person

/* 
4.  List all events that can cause a trigger to be executed.
*/ 
-- [answer] INSERT, DELETE, UPDATE 

/* 
5. Generate a destination schema in 3rd Normal Form.  
Include all necessary fact, join, and dictionary tables, and all Primary and Foreign Key relationships.  
The following assumptions can be made:

a. Each Company can have one or more Divisions.
b. Each record in the Company table represents a unique combination 
c. Physical locations are associated with Divisions.
d. Some Company Divisions are collocated at the same physical of Company Name and Division Name.
e. Contacts can be associated with one or more divisions and the address, 
but are differentiated by suite/mail drop records.
status of each association should be separately maintained and audited.
*/ 

CREATE TABLE Divisions (companyName varchar(20) not null, divisionName varchar(20) primary key) 
CREATE TABLE Locations (divisionName varchar(20) primary key, Location varchar(50) not null, Suite varchar(10) null) 
CREATE TABLE Contacts (contactName varchar(20) primary key, 
division varchar(20) not null foreign key references divisions(divisionName))



