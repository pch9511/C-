--	테이블명: ChatLog
--  기능 : 채팅로그 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[ChatLog]
(
	[Id] NvarChar(30) NOT NULL References Login(Id),
	[Name] NvarChar(20) NOT NULL,
	[Content] NvarChar(100) NOT NULL,
	[Date] DateTime Default(GetDaTe())
)
