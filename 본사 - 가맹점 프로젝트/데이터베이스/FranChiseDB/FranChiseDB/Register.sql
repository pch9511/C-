--	���̺��: Register
--  ��� : ȸ������ ��û ������ �����ϴ� DB
--  ���糯¥: 2023-03-07

USE Franchise

--DROP TABLE [Register]

/*CREATE TABLE [dbo].[Register]
(
	[Id] NvarChar(25) NOT NULL,
	[Password] NvarChar(20) NOT NULL,
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[State] bit NOT NULL default('false'),
	[Date] DateTime NOT NULL Default(GetDate())
)*/

--INSERT INTO [Register] VALUES('TEST','112223344','1234567890','false',GETDATE())

--UPDATE [Register] SET [State] = 'false' WHERE Id = '�ѱ�0624567'

--DELETE FROM [Register] 

SELECT * FROM [Register]