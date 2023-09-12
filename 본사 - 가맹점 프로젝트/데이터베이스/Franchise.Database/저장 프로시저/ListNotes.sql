CREATE Proc [dbo].[ListNotes]
	@Page INT
AS
	With DotNetNoteOrderedLists
	AS
	(
		Select 
			[Id], [Name], [Email], [Title], [PostDate], [ReadCount],
			[Ref], [Step], [RefOrder], [AnswerNum], [ParentNum],
			[CommentCount], [FileName], [FileSize], [DownCount],
			ROW_NUMBER() Over (Order By Ref Desc, RefOrder Asc)
			AS 'RowNumber'
		FROM Note
	)
	Select * From DotNetNoteOrderedLists
	Where RowNumber Between @Page * 10 + 1 And (@Page + 1) * 10
