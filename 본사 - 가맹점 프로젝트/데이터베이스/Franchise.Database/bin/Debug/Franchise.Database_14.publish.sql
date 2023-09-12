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
PRINT N'[dbo].[DeleteNote] 변경 중...';


GO
ALTER Proc DeleteNote
	@Id Int
AS
	Declare @cnt INT
	Select @cnt = Count(*) From Note
	Where Id = @Id

	if @cnt = 0
	Begin
		Return 0 -- 번호와 암호가 맞는게 없으면 0을 반환
	End

	Declare @AnswerNum INT
	Declare @RefOrder INT
	Declare @Ref INT
	Declare @ParentNum INT

	Select 
		@AnswerNum = AnswerNum, @RefOrder = RefOrder,
		@Ref = Ref, @ParentNum = ParentNum
	From Note
	Where Id = @Id

	if @AnswerNum = 0
	Begin
		if @RefOrder > 0
		Begin
			Update Note Set RefOrder = RefOrder - 1
			Where Ref = @Ref And RefOrder = @RefOrder
			Update Note Set AnswerNum = AnswerNum - 1 Where Id = @ParentNum
		End
		Delete Note Where Id = @Id
		Delete Note
		Where
			Id = @ParentNum And ModifyIP = N'((DELETED))' AND AnswerNum = 0
	END
	ELSE
	Begin
		Update Note
		Set
			Name = N'(Unknown)', Email = '', RegiNum = '',
			Title = N'(삭제된 글입니다.)',
			Content = N'(삭제된 글입니다. ' 
			+ N'현재 답변이 포함되어 있기 때문에 내용만 삭제되었습니다.)',
			ModifyIP = N'((DELETED))', FileName = '',
			FileSize = 0, CommentCount = 0
		Where Id = @Id
	End
GO
PRINT N'업데이트가 완료되었습니다.';


GO
