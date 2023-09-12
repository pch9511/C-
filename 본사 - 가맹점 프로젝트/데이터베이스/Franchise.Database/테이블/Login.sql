--	테이블명: Login
--  기능 : 로그인 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[Login]
(
	[Id] NvarChar(30) NOT NULL PRIMARY KEY,
	[Password] NvarChar(50) NOT NULL,
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Check] Bit	Null Default 'false'
)
