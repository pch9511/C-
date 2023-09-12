--	���̺��: HeadStock
--  ��� : ��������� ������ �����ϴ� DB
--  ���糯¥: 2023-03-03

--USE Franchise

DROP TABLE HeadStock

CREATE TABLE [dbo].[HeadStock]
(
	[Id] NvarChar(25) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NULL ,
	[Name] NvarChar(30) NOT NULL,
	[InPrice] Int NOT NULL,
	[OutPrice] int NULL,
	[Account] Int NOT NULL,
	[Date] DateTime Default(GETDATE()),
	[State] NvarChar(25) NOT NULL,
	[Pay] NvarChar(20) NULL
)
--INSERT INTO HeadStock VALUES('AA000','','TEST2',1000,'1200','5',Default,'�԰�','')

--UPDATE HeadStock SET Price=2000 Where Id='��ǰ������ȣ'

--DELETE FROM HeadStock Where RegiNum = '1234567'
/*Select isnull (sum(Account), 0) as ���� From HeadStock Where [State] = '���' Group By [Id]
Select a.[Id],[Name],[Price],sum(Account) - (Select isnull (sum(Account), 0) as ���� From HeadStock Where [State] = '���' and [Id] = a.[Id] Group By [Id]) as ���� 
	From HeadStock a Where [State] = '�԰�' Group By [Id],[Name],[Price] */

--Select [Id],[Name],[Price] From HeadStock Group By [Id],[Name],[Price]
--Select [Id], sum(Account) as ���� From HeadStock Group By [Id]
--Delete From HeadStock
SELECT * FROM HeadStock 

