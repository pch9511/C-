--	테이블명: Order
--  기능 : 가맹점이 본사에게 상품을 주문하는 정보를 저장하는 DB
--  만든날짜: 2023-03-03

USE Franchise

--DROP TABLE [Order]

/*CREATE TABLE [dbo].[Order]
(
	[Num] int NOT NULL PRIMARY KEY Identity(0,1),
	[Id] NvarChar(25) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Name] NvarChar(30) NOT NULL,
	[Price] Int NOT NULL,
	[Account] Int NOT NULL,
	[State] NvarChar(20) NOT NULL,
	[Pay] NvarChar(20) NOT NULL,
	[Date] DateTime Default(GETDATE())
)*/


--INSERT INTO [Order] VALUES('CA000','123456','상품명',1000,10,'주문(승인전)',Default)

--UPDATE [Order] SET [State]='배송중' Where Num = 4

--DELETE FROM [Order]
--DBCC CHECKIDENT('Order', RESEED, 0)
SELECT * FROM [Order] 
