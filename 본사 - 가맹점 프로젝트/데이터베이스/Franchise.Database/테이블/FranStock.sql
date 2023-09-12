--	테이블명: FranStock
--  기능 : 가맹점재고 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[FranStock]
(
	[Id] NvarChar(50) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Name] NvarChar(30) NOT NULL,
	[Price] Int NOT NULL,
	[Account] Int NOT NULL,
	[Date] DateTime Default(GETDATE())
)
