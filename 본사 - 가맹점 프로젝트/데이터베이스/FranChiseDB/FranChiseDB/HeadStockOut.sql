--	���̺��: HeadStockOut
--  ��� : ��������� ��� ������ �����ϴ� DB
--  ���糯¥: 2023-03-03

USE Franchise

DROP TABLE HeadStockOut

/*CREATE TABLE [dbo].[HeadStockOut]
(
	[Id] NvarChar(25) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Name] NvarChar(30) NOT NULL,
	[Price] Int NOT NULL,
	[Account] Int NOT NULL,
	[Date] DateTime Default(GETDATE())
)*/

--INSERT INTO HeadStockOut VALUES('��ǰ������ȣ','����ڵ�Ϲ�ȣ','��ǰ��',1000,10,Default)

--UPDATE HeadStockOut SET Price=2000 WHERE Id='��ǰ������ȣ'

--DELETE FROM HeadStockOut

SELECT * FROM HeadStockOut