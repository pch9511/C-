--	테이블명: Client
--  기능 : 회원 정보를 저장하는 DB
--  만든날짜: 2023-04-21

USE Franchise

--DROP TABLE [Client]

/*CREATE TABLE [dbo].[Client]
(
	[Id] int NOT NULL PRIMARY KEY Identity(0,1),
	[Name] NvarChar(30) NOT NULL,
	[Phone] NvarChar(25) NOT NULL,
	[Point] int NOT NULL
)*/
	
--INSERT INTO [Client] VALUES('1','1','1','false')

--UPDATE [Client] SET [Id] = '1234567', [Password] = '123456', [Check]=1  WHERE RegiNum = '1234567'

--DELETE FROM [Client] Where Id = 'TEST'

SELECT * FROM [Client]
