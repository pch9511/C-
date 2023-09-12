Create Proc DeleteNote
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
