--	���̺��: FranchiseInfo
--  ��� : ������ ������ �����ϴ� DB
--  ���糯¥: 2023-02-28

USE Franchise
--DROP TABLE FranchiseInfo

/*CREATE TABLE [dbo].[FranchiseInfo]
(
	[Name] NvarChar(20) Not Null,
	[OwnerName] NvarChar(10) Not Null,
	[OwnerPhoneNumber] NvarChar(25) Not Null,
	[RegistrationNumber] NvarChar(30) Not Null PRIMARY KEY,
	[ContactNumber] NvarChar(30) Not Null,
	[Address] NvarChar(30) Not Null,
	[Date] Datetime	Default(GetDate())
)*/

--INSERT INTO FranchiseInfo VALUES('�̸�','��������','�������ֹ�ȣ','����ڵ�Ϲ�ȣ','����ó','�ּ�',GetDate())

--UPDATE FranchiseInfo SET [Check] = 'true' Where RegistrationNumber='����ڵ�Ϲ�ȣ' 

--DELETE FROM FranchiseInfo

--INSERT ALL INTO FranchiseInfo VALUES('TEST','TEST','TEST','TEST','TEST','TEST',GetDate())
--INSERT INTO Login VALUES('TEST','TEST','false')
--UPDATE FranchiseInfo SET [ContactNumber] = '06212345678' Where RegistrationNumber='1234567890' 

SELECT * FROM FranchiseInfo

