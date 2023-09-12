--	테이블명: Category
--  기능 : 카테고리 정보를 저장하는 DB
--  만든날짜: 2023-03-03
USE Franchise

/*CREATE TABLE [dbo].[Category]
(
	[Id] NvarChar(3) NOT NULL PRIMARY KEY,
	[Name] NvarChar(20) NOT NULL,
	[Level] Int NOT NULL,
	[Parent] NvarChar(20) NULL
)*/

Select * From Category

--INSERT INTO Category VALUES('C', '종이컵')

--UPDATE Category SET Id = 'B' ,[Name] = '원두' WHERE Id='C'

--DELETE FROM Category

--Delete From Category Where [Id] = 'A'