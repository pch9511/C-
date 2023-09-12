/*
master의 배포 스크립트

이 코드는 도구를 사용하여 생성되었습니다.
파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
변경 내용이 손실됩니다.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "master"
:setvar DefaultFilePrefix "master"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER2\MSSQL\DATA\"

GO
:on error exit
GO
/*
SQLCMD 모드가 지원되지 않으면 SQLCMD 모드를 검색하고 스크립트를 실행하지 않습니다.
SQLCMD 모드를 설정한 후에 이 스크립트를 다시 사용하려면 다음을 실행합니다.
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'이 스크립트를 실행하려면 SQLCMD 모드를 사용하도록 설정해야 합니다.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'[dbo].[FranchiseInfo]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[FranchiseInfo] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (20) NOT NULL,
    [OwnerName]          NVARCHAR (10) NOT NULL,
    [OwnerPhoneNumber]   NVARCHAR (25) NOT NULL,
    [RegistrationNumber] NVARCHAR (30) NOT NULL,
    [ContactNumber]      NVARCHAR (30) NOT NULL,
    [Address]            NVARCHAR (30) NOT NULL,
    [Check]              BIT           NULL,
    PRIMARY KEY CLUSTERED ([RegistrationNumber] ASC)
);


GO
PRINT N'[dbo].[FranchiseInfo]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[FranchiseInfo]
    ADD DEFAULT 'false' FOR [Check];


GO
PRINT N'업데이트가 완료되었습니다.';


GO
