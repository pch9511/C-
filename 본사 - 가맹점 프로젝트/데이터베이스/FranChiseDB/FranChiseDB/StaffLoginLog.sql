--	테이블명: StaffLoginLog
--  기능 : 직원의 로그인기록 정보를 저장하는 DB
--  만든날짜: 2023-04-13

USE Franchise

--DROP TABLE StaffLoginLog

/*CREATE TABLE [dbo].[StaffLoginLog]
(
	[Id] NvarChar(25) References StaffLogin(Id),
	[Name] NvarChar(25) NOT NULL,
	[Log] NvarChar(10) NOT NULL,
	[Time] DateTime Default(GetDate()),
	[RegiNum] NvarChar(30) NOT NULL References FranchiseInfo(RegistrationNumber)
)*/

--INSERT INTO LoginLog VALUES('아이디', '로그인', GETDATE())

--UPDATE LoginLog SET Time=GetDate() WHERE Id='아이디'

-- DELETE FROM StaffLoginLog

SELECT * FROM StaffLoginLog