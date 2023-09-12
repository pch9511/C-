/*
Franchise의 배포 스크립트

이 코드는 도구를 사용하여 생성되었습니다.
파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
변경 내용이 손실됩니다.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Franchise"
:setvar DefaultFilePrefix "Franchise"
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
PRINT N'[dbo].[Category]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Category] (
    [Id]   NVARCHAR (30) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[ChatLog]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[ChatLog] (
    [Id]      NVARCHAR (30)  NOT NULL,
    [Name]    NVARCHAR (20)  NOT NULL,
    [Content] NVARCHAR (100) NOT NULL,
    [Date]    DATETIME       NULL
);


GO
PRINT N'[dbo].[FranStock]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[FranStock] (
    [Id]      NVARCHAR (50) NOT NULL,
    [RegiNum] NVARCHAR (30) NOT NULL,
    [Name]    NVARCHAR (30) NOT NULL,
    [Price]   INT           NOT NULL,
    [Account] INT           NOT NULL,
    [Date]    DATETIME      NULL
);


GO
PRINT N'[dbo].[HeadStock]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[HeadStock] (
    [Id]      NVARCHAR (50) NOT NULL,
    [Name]    NVARCHAR (30) NOT NULL,
    [Price]   INT           NOT NULL,
    [Account] INT           NOT NULL,
    [Date]    DATETIME      NULL
);


GO
PRINT N'[dbo].[HeadStockOut]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[HeadStockOut] (
    [Id]      NVARCHAR (50) NOT NULL,
    [RegiNum] NVARCHAR (30) NOT NULL,
    [Name]    NVARCHAR (30) NOT NULL,
    [Price]   INT           NOT NULL,
    [Account] INT           NOT NULL,
    [Date]    DATETIME      NULL
);


GO
PRINT N'[dbo].[Login]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Login] (
    [Id]       NVARCHAR (30) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Check]    BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[LoginLog]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[LoginLog] (
    [Id]   NVARCHAR (30) NOT NULL,
    [Log]  NVARCHAR (10) NOT NULL,
    [Time] DATETIME      NULL
);


GO
PRINT N'[dbo].[Note]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Note] (
    [Id]       NVARCHAR (30)  NOT NULL,
    [Category] NVARCHAR (10)  NOT NULL,
    [Title]    NVARCHAR (100) NOT NULL,
    [Content]  NVARCHAR (300) NOT NULL,
    [Date]     DATETIME       NULL
);


GO
PRINT N'[dbo].[Order]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Order] (
    [Id]      NVARCHAR (50) NOT NULL,
    [RegiNum] NVARCHAR (30) NOT NULL,
    [Name]    NVARCHAR (30) NOT NULL,
    [Price]   INT           NOT NULL,
    [Account] INT           NOT NULL,
    [State]   NVARCHAR (10) NOT NULL,
    [Date]    DATETIME      NULL
);


GO
PRINT N'[dbo].[Pay]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Pay] (
    [RegiNum] NVARCHAR (30)  NOT NULL,
    [Option]  NVARCHAR (10)  NOT NULL,
    [Price]   INT            NOT NULL,
    [Content] NVARCHAR (100) NOT NULL,
    [Date]    DATETIME       NULL
);


GO
PRINT N'[dbo].[Product]을(를) 만드는 중...';


GO
CREATE TABLE [dbo].[Product] (
    [Id]       NVARCHAR (50) NOT NULL,
    [Name]     NVARCHAR (30) NOT NULL,
    [Category] NVARCHAR (20) NOT NULL,
    [Price]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[ChatLog]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[ChatLog]
    ADD DEFAULT (GetDaTe()) FOR [Date];


GO
PRINT N'[dbo].[FranStock]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[FranStock]
    ADD DEFAULT (GETDATE()) FOR [Date];


GO
PRINT N'[dbo].[HeadStock]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[HeadStock]
    ADD DEFAULT (GETDATE()) FOR [Date];


GO
PRINT N'[dbo].[HeadStockOut]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[HeadStockOut]
    ADD DEFAULT (GETDATE()) FOR [Date];


GO
PRINT N'[dbo].[Login]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Login]
    ADD DEFAULT 'false' FOR [Check];


GO
PRINT N'[dbo].[LoginLog]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[LoginLog]
    ADD DEFAULT (GetDate()) FOR [Time];


GO
PRINT N'[dbo].[Note]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Note]
    ADD DEFAULT (GetDate()) FOR [Date];


GO
PRINT N'[dbo].[Order]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Order]
    ADD DEFAULT (GETDATE()) FOR [Date];


GO
PRINT N'[dbo].[Pay]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Pay]
    ADD DEFAULT (GetDate()) FOR [Date];


GO
PRINT N'[dbo].[ChatLog]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[ChatLog] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Login] ([Id]);


GO
PRINT N'[dbo].[FranStock]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[FranStock] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'[dbo].[FranStock]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[FranStock] WITH NOCHECK
    ADD FOREIGN KEY ([RegiNum]) REFERENCES [dbo].[FranchiseInfo] ([RegistrationNumber]);


GO
PRINT N'[dbo].[HeadStock]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[HeadStock] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'[dbo].[HeadStockOut]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[HeadStockOut] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'[dbo].[HeadStockOut]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[HeadStockOut] WITH NOCHECK
    ADD FOREIGN KEY ([RegiNum]) REFERENCES [dbo].[FranchiseInfo] ([RegistrationNumber]);


GO
PRINT N'[dbo].[LoginLog]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[LoginLog] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Login] ([Id]);


GO
PRINT N'[dbo].[Note]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Note] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Login] ([Id]);


GO
PRINT N'[dbo].[Order]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Order] WITH NOCHECK
    ADD FOREIGN KEY ([Id]) REFERENCES [dbo].[Product] ([Id]);


GO
PRINT N'[dbo].[Order]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Order] WITH NOCHECK
    ADD FOREIGN KEY ([RegiNum]) REFERENCES [dbo].[FranchiseInfo] ([RegistrationNumber]);


GO
PRINT N'[dbo].[Pay]에 대한 명명되지 않은 제약 조건을(를) 만드는 중...';


GO
ALTER TABLE [dbo].[Pay] WITH NOCHECK
    ADD FOREIGN KEY ([RegiNum]) REFERENCES [dbo].[FranchiseInfo] ([RegistrationNumber]);


GO
PRINT N'새로 만든 제약 조건에 대해 기존 데이터를 검사하는 중입니다.';


GO
USE [$(DatabaseName)];


GO
CREATE TABLE [#__checkStatus] (
    id           INT            IDENTITY (1, 1) PRIMARY KEY CLUSTERED,
    [Schema]     NVARCHAR (256),
    [Table]      NVARCHAR (256),
    [Constraint] NVARCHAR (256)
);

SET NOCOUNT ON;

DECLARE tableconstraintnames CURSOR LOCAL FORWARD_ONLY
    FOR SELECT SCHEMA_NAME([schema_id]),
               OBJECT_NAME([parent_object_id]),
               [name],
               0
        FROM   [sys].[objects]
        WHERE  [parent_object_id] IN (OBJECT_ID(N'dbo.ChatLog'), OBJECT_ID(N'dbo.FranStock'), OBJECT_ID(N'dbo.HeadStock'), OBJECT_ID(N'dbo.HeadStockOut'), OBJECT_ID(N'dbo.LoginLog'), OBJECT_ID(N'dbo.Note'), OBJECT_ID(N'dbo.Order'), OBJECT_ID(N'dbo.Pay'))
               AND [type] IN (N'F', N'C')
                   AND [object_id] IN (SELECT [object_id]
                                       FROM   [sys].[check_constraints]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0
                                       UNION
                                       SELECT [object_id]
                                       FROM   [sys].[foreign_keys]
                                       WHERE  [is_not_trusted] <> 0
                                              AND [is_disabled] = 0);

DECLARE @schemaname AS NVARCHAR (256);

DECLARE @tablename AS NVARCHAR (256);

DECLARE @checkname AS NVARCHAR (256);

DECLARE @is_not_trusted AS INT;

DECLARE @statement AS NVARCHAR (1024);

BEGIN TRY
    OPEN tableconstraintnames;
    FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
    WHILE @@fetch_status = 0
        BEGIN
            PRINT N'제약 조건 검사 중: ' + @checkname + N' [' + @schemaname + N'].[' + @tablename + N']';
            SET @statement = N'ALTER TABLE [' + @schemaname + N'].[' + @tablename + N'] WITH ' + CASE @is_not_trusted WHEN 0 THEN N'CHECK' ELSE N'NOCHECK' END + N' CHECK CONSTRAINT [' + @checkname + N']';
            BEGIN TRY
                EXECUTE [sp_executesql] @statement;
            END TRY
            BEGIN CATCH
                INSERT  [#__checkStatus] ([Schema], [Table], [Constraint])
                VALUES                  (@schemaname, @tablename, @checkname);
            END CATCH
            FETCH tableconstraintnames INTO @schemaname, @tablename, @checkname, @is_not_trusted;
        END
END TRY
BEGIN CATCH
    PRINT ERROR_MESSAGE();
END CATCH

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') >= 0
    CLOSE tableconstraintnames;

IF CURSOR_STATUS(N'LOCAL', N'tableconstraintnames') = -1
    DEALLOCATE tableconstraintnames;

SELECT N'제약 조건 확인 실패:' + [Schema] + N'.' + [Table] + N',' + [Constraint]
FROM   [#__checkStatus];

IF @@ROWCOUNT > 0
    BEGIN
        DROP TABLE [#__checkStatus];
        RAISERROR (N'제약 조건을 확인하는 동안 오류가 발생했습니다.', 16, 127);
    END

SET NOCOUNT OFF;

DROP TABLE [#__checkStatus];


GO
PRINT N'업데이트가 완료되었습니다.';


GO
