--	테이블명: Product
--  기능 : 상품 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[Product]
(
	[Id] NvarChar(50) NOT NULL PRIMARY KEY,
	[Name] NvarChar(30) NOT NULL,
	[Category] NvarChar(20) NOT NULL,
	[Price] Int NOT NULL
)
