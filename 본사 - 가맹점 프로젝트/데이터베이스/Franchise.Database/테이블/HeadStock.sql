--	테이블명: HeadStock
--  기능 : 본사의재고 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[HeadStock]
(
	[Id] NvarChar(50) NOT NULL References Product(Id),
	[Name] NvarChar(30) NOT NULL,
	[Price] Int NOT NULL,
	[Account] Int NOT NULL,
	[Date] DateTime Default(GETDATE())
)
