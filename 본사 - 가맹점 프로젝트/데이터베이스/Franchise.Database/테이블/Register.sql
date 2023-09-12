--	테이블명: Register
--  기능 : 회원가입 요청 정보를 저장하는 DB
--  만든날짜: 2023-03-07

--DROP TABLE [Register]

CREATE TABLE [dbo].[Register]
(
	[Id] NvarChar(25) NOT NULL,
	[Password] NvarChar(20) NOT NULL,
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[State] bit NOT NULL default('false')
)

--INSERT INTO [Register] VALUES('1','1','1','false')

--UPDATE [Register] SET [State] = '승인대기' WHERE Id = '아이디'

--DELETE FROM [Register] Where Id = 'TEST'

--SELECT * FROM [Register]