--	���̺��: StaffLogin
--  ��� : POS�� ��ϵ� ������ �α��� ������ �����ϴ� DB
--  ���糯¥: 2023-04-11

USE Franchise

--DROP TABLE [StaffLogin]

/*CREATE TABLE [dbo].[StaffLogin]
(
	[Id] NvarChar(25) NOT NULL PRIMARY KEY,
	[Name] NvarChar(25) NOT NULL,
	[Password] NvarChar(20) NOT NULL,
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber)
)*/

--Delete From StaffLogin

Select * From StaffLogin