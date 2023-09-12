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
	@FileSize	INT,
	@Category   NVARCHAR(10)
AS
	Declare @MaxRefOrder INT
	Declare @MaxRefAnswerNum INT
	Declare @ParentRef INT
	Declare @ParentStep INT
	Declare @ParentRefOrder Int

	--부모글의 답변수 1 증가
	Update Note Set AnswerNum = AnswerNum + 1 Where Id = @ParentNum

	--같은 글에서 답변을 두 번 이상하면 먼저 답변한게 위에 나타남
	Select @MaxRefOrder = RefOrder, @MaxRefAnswerNum = AnswerNum From Note
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
		Homepage, Ref, Step, RefOrder, ParentNum, FileName, FileSize , Category
	)
	Values
	(
		@Name, @Email, @Title, @PostIP, @Content, @RegiNum, @Encoding,
		@Homepage, @ParentRef, @ParentStep + 1, @MaxRefOrder + @MaxRefAnswerNum + 1,
		@ParentNum, @FileName, @FileSize , @Category
	)

	