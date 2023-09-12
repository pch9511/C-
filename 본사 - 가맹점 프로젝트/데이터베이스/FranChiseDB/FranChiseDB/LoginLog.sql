--	테이블명: LoginLog
--  기능 : 로그인기록 정보를 저장하는 DB
--  만든날짜: 2023-03-03

USE Franchise

--DROP TABLE LoginLog

/*CREATE TABLE [dbo].[LoginLog]
(
	[Id] NvarChar(25),
	[Log] NvarChar(10) NOT NULL,
	[Time] DateTime Default(GetDate())
)*/

--INSERT INTO LoginLog VALUES('아이디', '로그인', GETDATE())

--UPDATE LoginLog SET Time=GetDate() WHERE Id='아이디'

-- DELETE FROM LoginLog

SELECT * FROM LoginLog