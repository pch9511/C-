--	테이블명: ChatLog
--  기능 : 채팅로그 정보를 저장하는 DB
--  만든날짜: 2023-03-03

USE Franchise

--DROP TABLE ChatLog
/*CREATE TABLE [dbo].[ChatLog]
(
	[State] NvarChar(25) NOT NULL,
	[Question] NvarChar(100) NULL,
	[ChatLog] NvarChar(100) NOT NULL,
	[Date] DateTime Default(GetDaTe())
)*/

--INSERT INTO ChatLog VALUES('답변','질문3','4',GetDate())

--UPDATE ChatLog SET Content = '내용+2' WHERE Id='아이디'

--DELETE FROM ChatLog Where Question = '질문3'

--SELECT * From [FranchiseInfo]
SELECT * FROM ChatLog
--Select [Question],[Content] From [ChatLog] Where State = '답변'