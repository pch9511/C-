--	테이블명: Menu
--  기능 : 메뉴 정보를 담는 DB
--  만든날짜: 2023-04-20

USE Franchise

--DROP TABLE [Menu]

/*CREATE TABLE [dbo].[Menu]
(
	[Id] int NOT NULL PRIMARY KEY Identity(0,1),
	[Name] NvarChar(30) NOT NULL,
	[Category] NvarChar(20) NOT NULL,
	[Price] Int NOT NULL,
	[UseProduct] NvarChar(25) NOT NULL References Product(Id),
	[UseAccount] int NOT NULL
)*/


--INSERT INTO Menu VALUES('커피1','Coffee',3000,'BDA000',1)

--UPDATE Menu SET Name='커피3' Where Id ='2'

--DELETE FROM Menu

SELECT * FROM Menu	

SELECT * From FranStock