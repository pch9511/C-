--	���̺��: ChatLog
--  ��� : ä�÷α� ������ �����ϴ� DB
--  ���糯¥: 2023-03-03

USE Franchise

--DROP TABLE ChatLog
/*CREATE TABLE [dbo].[ChatLog]
(
	[State] NvarChar(25) NOT NULL,
	[Question] NvarChar(100) NULL,
	[ChatLog] NvarChar(100) NOT NULL,
	[Date] DateTime Default(GetDaTe())
)*/

--INSERT INTO ChatLog VALUES('�亯','����3','4',GetDate())

--UPDATE ChatLog SET Content = '����+2' WHERE Id='���̵�'

--DELETE FROM ChatLog Where Question = '����3'

--SELECT * From [FranchiseInfo]
SELECT * FROM ChatLog
--Select [Question],[Content] From [ChatLog] Where State = '�亯'