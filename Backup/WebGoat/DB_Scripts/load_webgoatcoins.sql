/******************************************************************************
 * Copyright (c) 2005 Actuate Corporation.
 * All rights reserved. This file and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http:/www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *  Actuate Corporation  - initial implementation
 *
 * Classic Models Inc. sample database developed as part of the
 * Eclipse BIRT Project. For more information, see http:/www.eclipse.org/birt
 *
 *******************************************************************************/

/* Loads the Classic Models tables using the MySQL LOAD command */

/* Preparing the load files for importing. Input file requirements:
     - Column order in the file must be the same as the columns in the table
     - Columns are Comma delimited
     - Text is quoted (")
     - NULL columns must be ,NULL,  ( ,, is not acceptable)
     - Dates must be in YYYY-MM-DDD format

   Input files expected in the datafiles direcory, parallel to this script.
*/


/* First make sure all the tables are empty */

DELETE FROM Customers;
DELETE FROM CustomerLogin;
DELETE FROM SecurityQuestions;
DELETE FROM Employees;
DELETE FROM Offices;
DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM Payments;
DELETE FROM Products;
DELETE FROM Categories;
DELETE FROM Comments;


/* Load records into the tables. There should be no warnings.*/

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/customers.txt' INTO TABLE Customers
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/customerlogin.txt' INTO TABLE CustomerLogin
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/securityquestions.txt' INTO TABLE SecurityQuestions
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/employees.txt' INTO TABLE Employees
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/offices.txt' INTO TABLE Offices
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/orderdetails.txt' INTO TABLE OrderDetails
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/orders.txt' INTO TABLE Orders
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/payments.txt' INTO TABLE Payments
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 100;

LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/categories.txt' INTO TABLE Categories 
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';
          
SHOW WARNINGS LIMIT 100;


LOAD DATA LOCAL INFILE 'DB_Scripts/datafiles/products.txt' INTO TABLE Products
          FIELDS TERMINATED BY '|' LINES TERMINATED BY '\n';

SHOW WARNINGS LIMIT 10;

