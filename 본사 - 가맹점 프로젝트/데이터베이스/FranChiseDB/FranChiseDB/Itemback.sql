
DROP TABLE [Itemback]

CREATE TABLE [dbo].[Itemback]
(
	[Num] int NOT NULL PRIMARY KEY Identity(0,1),
	[Id] NvarChar(25) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Name] NvarChar(30) NOT NULL,
	[InPrice] int NOT NULL,
	[OutPrice] Int NOT NULL,
	[Account] Int NOT NULL,
	[State] NvarChar(20) NOT NULL,
	[Date] DateTime Default(GETDATE())
)


--INSERT INTO [Itemback] VALUES('CA000','123456','상품명',1000,10,'주문(승인전)',Default)

--UPDATE [Itemback] SET [State]='배송중' Where Num = 4

--DELETE FROM [Itemback]
SELECT * FROM Itemback 
