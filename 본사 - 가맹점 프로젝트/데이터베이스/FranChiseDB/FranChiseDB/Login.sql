--	테이블명: Login
--  기능 : 로그인 정보를 저장하는 DB
--  만든날짜: 2023-03-03

USE Franchise

--DROP TABLE [Login]

/*CREATE TABLE [dbo].[Login]
(
	[Id] NvarChar(25) NOT NULL PRIMARY KEY,
	[Password] NvarChar(20) NOT NULL,
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Check] Bit	Null Default 'false'
)*/
	
--INSERT INTO [Login] VALUES('1234567890','01012345678','1234567890','false')

--UPDATE [Login] SET [Id] = '1234567', [Password] = '123456', [Check]=1  WHERE RegiNum = '1234567'

--DELETE FROM [Login] 

SELECT * FROM [Login]



	