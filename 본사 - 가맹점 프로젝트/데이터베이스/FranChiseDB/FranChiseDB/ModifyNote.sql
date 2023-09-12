
Create Proc ModifyNote
	@Name		NVARCHAR(25),
	@Email		NVARCHAR(100),
	@Title		NVARCHAR(150),
	@ModifyIP	NVARCHAR(15),
	@Content	NText,
	@RegiNum	NVARCHAR(30),
	@Encoding	NVARCHAR(10),
	@Homepage	NVARCHAR(100),
	@FileName	NVARCHAR(255),
	@FileSize	INT,
	@Category   NVARCHAR(10),
	@Id INT
AS
	Declare @cnt INT

	Select @cnt = Count(*) From Note
	Where Id = @Id And RegiNum = @RegiNum

	if @cnt > 0
	Begin
		Update Note
		Set
			Name = @Name, Email = @Email, Title = @Title,
			ModifyIP = @ModifyIP, ModifyDate = GetDate(),
			Content = @Content, Encoding = @Encoding,
			Homepage = @Homepage, FileName = @FileName, FileSize = @FileSize,
			Category = @Category
		Where Id = @Id

		Select '1'
	End
	else
		Select '0'
