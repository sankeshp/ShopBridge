create database ShopBridgeDB;

use ShopBridgeDB;


CREATE TABLE Item (
    Id int not null,
    Name varchar(255),
    Description varchar(255),
    Prize int
);


INSERT INTO Item
VALUES (1, 'Mobile', 'MI', 15000);

