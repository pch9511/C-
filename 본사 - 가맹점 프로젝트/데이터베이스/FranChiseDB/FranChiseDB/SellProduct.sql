
--DROP TABLE [SellProduct]

/*CREATE TABLE [dbo].[SellProduct]
(
	[Num] int NOT NULL PRIMARY KEY Identity(0,1),
	--[Id] NvarChar(25) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NOT NULL,
	[Name] NvarChar(30) NOT NULL,
	[Price] int NOT NULL,
	[Account] Int NOT NULL,
	--[State] NvarChar(20) NOT NULL,
	[Date] DateTime Default(GETDATE())
)*/


--INSERT INTO [SellProduct] VALUES('123456','커피2',3000,1,Default)

--UPDATE [SellProduct] SET [State]='배송중' Where Num = 4

--DELETE FROM [SellProduct]
SELECT * FROM SellProduct 