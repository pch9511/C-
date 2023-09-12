--	테이블명: Pay
--  기능 : POS에서 결제를 진행한 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[Pay]
(
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber),
	[Option] NvarChar(10) NOT NULL,
	[Price] Int NOT NULL,
	[Content] NvarChar(100) NOT NULL,
	[Date] DateTime Default(GetDate())
)
