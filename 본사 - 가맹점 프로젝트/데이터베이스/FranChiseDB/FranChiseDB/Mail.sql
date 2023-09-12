--	테이블명: Mail
--  기능 : 메일함 정보를 저장하는 DB
--  만든날짜: 2023-03-23

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

--INSERT INTO Mail VALUES('123456','1', '제목','내용','false',Default)

--UPDATE Mail SET Date= GetDATE() WHERE Id='아이디'

--Delete From Mail	

--Select * From Mail Where RegiNum = '123456'

--UPDATE Mail SET Content= 'Id = 한글0624567 Password = 11223344 입니다. 하단 버튼 클릭시 로그인창으로 돌아갑니다.' WHERE Id='Admin'
--UPDATE Mail SET [Read] = 'true' Where [Read] = 'false'
SELECT * FROM Mail