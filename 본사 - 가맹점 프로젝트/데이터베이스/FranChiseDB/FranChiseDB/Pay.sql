--	테이블명: Pay
--  기능 : POS에서 결제를 진행한 정보를 저장하는 DB
--  만든날짜: 2023-03-03

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



--INSERT INTO Pay Values('123456','현금',1000,'아메리카노 1잔',Default)

--UPDATE Pay SET [Option]='카드' WHERE RegiNum='사업자등록번호'

--DELETE FROM Pay

--Select * From Pay
--SELECT * FROM Pay Where [Option] = '현금' and [Date] Between '202304' and '202304'


--Select f.[Name],f.[Price],f.[Date], p.[Option], p.[Price], p.[Date] From FranStock f JOIN Pay p ON f.RegiNum = p.RegiNum 

--Select [Name],[Price],[Date] From FranStock UNION Select [Content],[Price],[Date] From Pay Order by [Date] Asc