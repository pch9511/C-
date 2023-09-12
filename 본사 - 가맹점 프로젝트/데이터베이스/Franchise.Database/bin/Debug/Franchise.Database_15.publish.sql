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
PRINT N'[dbo].[ReplyNote]을(를) 만드는 중...';


GO
Create Proc ReplyNote
	@Name		NVARCHAR(25),
	@Email		NVARCHAR(100),
	@Title		NVARCHAR(150),
	@PostIP		NVARCHAR(15),
	@Content	NText,
	@RegiNum	NVARCHAR(30),
	@Encoding	NVARCHAR(10),
	@Homepage	NVARCHAR(100),
	@ParentNum	INT,				--부모글 고유번호(Id)
	@FileName	NVARCHAR(255),
	@FileSize	INT
AS
	Declare @MaxRefOrder INT
	Declare @MaxRefAnswerNum INT
	Declare @ParentRef INT
	Declare @ParentStep INT
	Declare @ParentRefOrder Int

	--부모글의 답변수 1 증가
	Update Note Set AnswerNum = AnswerNum + 1 Where Id = @ParentNum

	--같은 글에서 답변을 두 번 이상하면 먼저 답변한게 위에 나타남
	Select @MaxRefOrder = RefOrder, @MaxRefAnswerNum = AnswerNum From Notes
		Where ParentNum = @ParentNum And
			RefOrder = (Select Max(RefOrder) From Note Where ParentNum = @ParentNum)

	if @MaxRefOrder IS NULL
	Begin
		Select @MaxRefOrder = RefOrder From Note Where Id = @ParentNum
		Set @MaxRefAnswerNum = 0
	End

	--중간에 답변을 달때
	Select @ParentRef = Ref, @ParentStep = Step From Note
		Where Id = @ParentNum

	Update Note Set refOrder = RefOrder + 1
		Where Ref = @ParentRef and RefOrder > (@MaxRefOrder + @MaxRefAnswerNum)

	--최종 저장
	Insert Note
	(
		Name, Email, Title, PostIP, Content, RegiNum, Encoding,
		Homepage, Ref, Step, RefOrder, ParentNum, FileName, FileSize
	)
	Values
	(
		@Name, @Email, @Title, @PostIP, @Content, @RegiNum, @Encoding,
		@Homepage, @ParentRef, @ParentStep + 1, @MaxRefOrder + @MaxRefAnswerNum + 1,
		@ParentNum, @FileName, @FileSize
	)
GO
PRINT N'업데이트가 완료되었습니다.';


GO
