--	테이블명: Register
--  기능 : 회원가입 요청 정보를 저장하는 DB
--  만든날짜: 2023-03-07

USE Franchise

--DROP TABLE [Register]

/*CREATE TABLE [dbo].[Register]
(
	[Id] NvarChar(25) NOT NULL,
	[Password] NvarChar(20) NOT NULL,
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[State] bit NOT NULL default('false'),
	[Date] DateTime NOT NULL Default(GetDate())
)*/

--INSERT INTO [Register] VALUES('TEST','112223344','1234567890','false',GETDATE())

--UPDATE [Register] SET [State] = 'false' WHERE Id = '한글0624567'

--DELETE FROM [Register] 

SELECT * FROM [Register]