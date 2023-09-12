--	테이블명: ChatLog
--  기능 : 채팅로그 정보를 저장하는 DB
--  만든날짜: 2023-03-03
USE Franchise

--DROP TABLE ChatRoom
/*CREATE TABLE [dbo].[ChatRoom]
(
	[Num] int NOT NULL PRIMARY KEY,
	[Name] NvarChar(20) NOT NULL,
	[Chatter] NvarChar(200) NOT NULL,
	[Date] DateTime Default(GetDaTe())
)*/

--SET @Cnt = 0;
--Update [ChatRoom] Set [ChatRoom].[Num] = @Cnt = @Cnt+1

--INSERT INTO ChatRoom VALUES('TEST','1234567 ',Default)

--UPDATE ChatRoom SET [Chatter] = '123456 ' Where Num = 2

--DELETE FROM ChatRoom 

--SELECT IDENT_CURRENT('ChatRoom')
--DBCC CHECKIDENT('ChatRoom',RESEED,4)
SELECT * FROM ChatRoom 
