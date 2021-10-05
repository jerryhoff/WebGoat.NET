/******************************************************************************
 * Copyright (c) 2005 Actuate Corporation.
 * All rights reserved. This file and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *  Actuate Corporation  - initial implementation
 *
 * Classic Models Inc. sample database developed as part of the
 * Eclipse BIRT Project. For more information, see http:\\www.eclipse.org\birt
 *
 *******************************************************************************/
/*******************************************************************************
* Changes made Jan 2012 - Copyright 2012
* Updated BIRT to be the webgoat coins database
* Images copyright US Mint and the Perth Mint
* Contributers:
*	Jerry Hoff - Infrared Security, LLC
*
*******************************************************************************/



/* Recommended DATABASE name is classicmodels. */

/* CREATE DATABASE classicmodels; */
/* USE classicmodels; */

/* DROP the existing tables. Comment this out if it is not needed. */

/* webgoat.net note: use name webgoat_coins" */


DROP TABLE Customers;
DROP TABLE CustomerLogin;
DROP TABLE SecurityQuestions;
DROP TABLE Employees;
DROP TABLE Offices;
DROP TABLE OrderDetails;
DROP TABLE Orders;
DROP TABLE Payments;
DROP TABLE Products;
DROP TABLE Categories;
DROP TABLE Comments;


/* Create the full set of Classic Models Tables */

CREATE TABLE Customers (
  customerNumber INTEGER NOT NULL AUTO_INCREMENT,
  customerName VARCHAR(50) NOT NULL,
  logoFileName VARCHAR(100) NULL,
  contactLastName VARCHAR(50) NOT NULL,
  contactFirstName VARCHAR(50) NOT NULL,
  phone VARCHAR(50) NOT NULL,
  addressLine1 VARCHAR(50) NOT NULL,
  addressLine2 VARCHAR(50) NULL,
  city VARCHAR(50) NOT NULL,
  state VARCHAR(50) NULL,
  postalCode VARCHAR(15) NULL,
  country VARCHAR(50) NOT NULL,
  salesRepEmployeeNumber INTEGER NULL,
  creditLimit DOUBLE NULL,
  PRIMARY KEY (customerNumber)
);

CREATE TABLE CustomerLogin (
	email VARCHAR(100) NOT NULL,
	customerNumber INTEGER NOT NULL,
	password VARCHAR(40) NOT NULL,
	question_id SMALLINT NULL,
	answer VARCHAR(50) NULL,
	PRIMARY KEY (email)
);

CREATE TABLE SecurityQuestions (
	question_id SMALLINT NOT NULL AUTO_INCREMENT,
	question_text VARCHAR(400) NOT NULL,
	PRIMARY KEY (question_id)
);


CREATE TABLE Employees (
  employeeNumber INTEGER NOT NULL AUTO_INCREMENT,
  lastName VARCHAR(50) NOT NULL,
  firstName VARCHAR(50) NOT NULL,
  extension VARCHAR(10) NOT NULL,
  email VARCHAR(100) NOT NULL,
  officeCode VARCHAR(10) NOT NULL,
  reportsTo INTEGER NULL,
  jobTitle VARCHAR(50) NOT NULL,
  PRIMARY KEY (employeeNumber)
);

CREATE TABLE Offices (
  officeCode VARCHAR(10) NOT NULL,
  city VARCHAR(50) NOT NULL,
  phone VARCHAR(50) NOT NULL,
  addressLine1 VARCHAR(50) NOT NULL,
  addressLine2 VARCHAR(50) NULL,
  state VARCHAR(50) NULL,
  country VARCHAR(50) NOT NULL,
  postalCode VARCHAR(15) NOT NULL,
  territory VARCHAR(10) NOT NULL,
  PRIMARY KEY (officeCode)
);

CREATE TABLE OrderDetails (
  orderNumber INTEGER NOT NULL,
  productCode VARCHAR(15) NOT NULL,
  quantityOrdered INTEGER NOT NULL,
  priceEach DOUBLE NOT NULL,
  orderLineNumber SMALLINT NOT NULL,
  PRIMARY KEY (orderNumber, productCode)
);

CREATE TABLE Orders (
  orderNumber INTEGER NOT NULL AUTO_INCREMENT,
  orderDate DATETIME NOT NULL,
  requiredDate DATETIME NOT NULL,
  shippedDate DATETIME NULL,
  status VARCHAR(15) NOT NULL,
  comments TEXT NULL,
  customerNumber INTEGER NOT NULL,
  PRIMARY KEY (orderNumber)
);


CREATE TABLE Payments (
  customerNumber INTEGER NOT NULL,  
  cardType VARCHAR(50) NOT NULL,
  creditCardNumber VARCHAR(50) NOT NULL,
  verificationCode SMALLINT NOT NULL,
  cardExpirationMonth VARCHAR(3) NOT NULL,
  cardExpirationYear VARCHAR(5) NOT NULL,  
  confirmationCode VARCHAR(50) NOT NULL,
  paymentDate DATETIME NOT NULL,
  amount DOUBLE NOT NULL,
  PRIMARY KEY (customerNumber, confirmationCode)
);

CREATE TABLE Categories(
  catNumber INTEGER NOT NULL AUTO_INCREMENT,
  catName VARCHAR(50) NOT NULL,
  catDesc TEXT NOT NULL,
  PRIMARY KEY (catNumber)
);

CREATE TABLE Products (
  productCode VARCHAR(15) NOT NULL,
  productName VARCHAR(200) NOT NULL,
  catNumber INTEGER NOT NULL,
  productImage VARCHAR(100) NOT NULL,
  productVendor VARCHAR(50) NOT NULL,
  productDescription TEXT NOT NULL,
  quantityInStock SMALLINT NOT NULL,
  buyPrice DOUBLE NOT NULL,
  MSRP DOUBLE NOT NULL,
  PRIMARY KEY (productCode)
);

CREATE TABLE Comments(
	commentNumber INTEGER NOT NULL AUTO_INCREMENT,
	productCode VARCHAR(15) NOT NULL,
	email VARCHAR(100) NOT NULL,
	comment TEXT NOT NULL,
	PRIMARY KEY (commentNumber)
);
