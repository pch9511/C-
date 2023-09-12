--	테이블명: LoginLog
--  기능 : 로그인기록 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[LoginLog]
(
	[Id] NvarChar(30), /*NULL References Login(Id),*/
	[Log] NvarChar(10) NOT NULL,
	[Time] DateTime Default(GetDate())
)
