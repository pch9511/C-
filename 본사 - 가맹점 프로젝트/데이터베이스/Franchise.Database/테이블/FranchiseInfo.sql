--	테이블명: FranchiseInfo
--  기능 : 가맹점 정보를 저장하는 DB
--  만든날짜: 2023-02-28
CREATE TABLE [dbo].[FranchiseInfo]
(
	[Name] NvarChar(20) Not Null,
	[OwnerName] NvarChar(10) Not Null,
	[OwnerPhoneNumber] NvarChar(25) Not Null,
	[RegistrationNumber] NvarChar(30) Not Null PRIMARY KEY,
	[ContactNumber] NvarChar(30) Not Null,
	[Address] NvarChar(30) Not Null,
	[Date] Datetime	Default(GetDate())
)

GO