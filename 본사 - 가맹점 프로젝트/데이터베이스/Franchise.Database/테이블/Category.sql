--	테이블명: Category
--  기능 : 카테고리 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[Category]
(
	[Id] NvarChar(30) NOT NULL PRIMARY KEY,
	[Name] NvarChar(20) NOT NULL
)
