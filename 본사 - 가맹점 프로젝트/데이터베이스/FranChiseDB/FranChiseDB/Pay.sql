--	���̺��: Pay
--  ��� : POS���� ������ ������ ������ �����ϴ� DB
--  ���糯¥: 2023-03-03

USE Franchise

--DROP TABLE Pay

/*CREATE TABLE [dbo].[Pay]
(
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Option] NvarChar(10) NOT NULL,
	[Price] Int NOT NULL,
	[Content] NvarChar(100) NOT NULL,
	[Date] DateTime Default(GetDate())
)*/



--INSERT INTO Pay Values('123456','����',1000,'�Ƹ޸�ī�� 1��',Default)

--UPDATE Pay SET [Option]='ī��' WHERE RegiNum='����ڵ�Ϲ�ȣ'

--DELETE FROM Pay

--Select * From Pay
--SELECT * FROM Pay Where [Option] = '����' and [Date] Between '202304' and '202304'


--Select f.[Name],f.[Price],f.[Date], p.[Option], p.[Price], p.[Date] From FranStock f JOIN Pay p ON f.RegiNum = p.RegiNum 

--Select [Name],[Price],[Date] From FranStock UNION Select [Content],[Price],[Date] From Pay Order by [Date] Asc