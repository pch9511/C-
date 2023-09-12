--	테이블명: Product
--  기능 : 상품 정보를 저장하는 DB
--  만든날짜: 2023-03-03

USE Franchise

--DROP TABLE [Product]

/*CREATE TABLE [dbo].[Product]
(
	[Id] NvarChar(25) NOT NULL PRIMARY KEY,
	[Name] NvarChar(30) NOT NULL,
	[Category] NvarChar(3) NOT NULL References Category(Id),
	[Price] Int NOT NULL
)*/


--INSERT INTO Product VALUES('AA000','다른이름','카테고리',1000)

--UPDATE Product SET Price=2000 Where Id ='상품고유번호'

SELECT * FROM Product

--Delete From Product


