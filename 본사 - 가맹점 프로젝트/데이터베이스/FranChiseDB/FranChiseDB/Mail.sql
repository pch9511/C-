--	���̺��: Mail
--  ��� : ������ ������ �����ϴ� DB
--  ���糯¥: 2023-03-23

USE Franchise

--DROP TABLE Mail

/*CREATE TABLE [dbo].[Mail]
(
	[Num] Int Not Null Primary Key Identity(0,1),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Id] NvarChar(25) NOT NULL,
	[Title] NvarChar(100) NOT NULL,
	[Content] NvarChar(300) NOT NULL,
	[Read] bit NOT NULL,
	[Date] DateTime Default(GetDate()) NOT NULL,
)*/

--INSERT INTO Mail VALUES('123456','1', '����','����','false',Default)

--UPDATE Mail SET Date= GetDATE() WHERE Id='���̵�'

--Delete From Mail	

--Select * From Mail Where RegiNum = '123456'

--UPDATE Mail SET Content= 'Id = �ѱ�0624567 Password = 11223344 �Դϴ�. �ϴ� ��ư Ŭ���� �α���â���� ���ư��ϴ�.' WHERE Id='Admin'
--UPDATE Mail SET [Read] = 'true' Where [Read] = 'false'
SELECT * FROM Mail