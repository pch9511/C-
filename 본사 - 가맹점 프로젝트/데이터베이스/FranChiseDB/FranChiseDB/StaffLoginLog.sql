--	���̺��: StaffLoginLog
--  ��� : ������ �α��α�� ������ �����ϴ� DB
--  ���糯¥: 2023-04-13

USE Franchise

--DROP TABLE StaffLoginLog

/*CREATE TABLE [dbo].[StaffLoginLog]
(
	[Id] NvarChar(25) References StaffLogin(Id),
	[Name] NvarChar(25) NOT NULL,
	[Log] NvarChar(10) NOT NULL,
	[Time] DateTime Default(GetDate()),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber)
)*/

--INSERT INTO LoginLog VALUES('���̵�', '�α���', GETDATE())

--UPDATE LoginLog SET Time=GetDate() WHERE Id='���̵�'

-- DELETE FROM StaffLoginLog

SELECT * FROM StaffLoginLog