--	���̺��: FranStock
--  ��� : ��������� ������ �����ϴ� DB
--  ���糯¥: 2023-03-03

USE Franchise

DROP TABLE FranStock

CREATE TABLE [dbo].[FranStock]
(
	[Id] NvarChar(25) NOT NULL References Product(Id),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Name] NvarChar(30) NOT NULL,
	[Price] Int NOT NULL,
	[Account] Int NOT NULL,
	[State] NvarChar(25) NOT NULL,
	[Date] DateTime Default(GETDATE())
)

--INSERT INTO FranStock VALUES('AA000','1234567','��ǰ��',1000,10,Default)

--UPDATE FranStock SET Id='CA001' WHERE RegiNum='123456' and Id = 'CA000'

--DELETE FROM FranStock

SELECT * FROM FranStock
