Create Proc WriteNote
	@Name		NVARCHAR(25),
	@Email		NVARCHAR(100),
	@Title		NVARCHAR(150),
	@PostIP		NVARCHAR(15),
	@Content	NTEXT,
	@RegiNum	NVARCHAR(30),
	@Encoding	NVARCHAR(10),
	@Homepage	NVARCHAR(100),
	@FileName	NVARCHAR(255),
	@FileSize	INT,
	@Category   NVARCHAR(10)
AS
	Declare @MaxRef INT
	Select @MaxRef = Max(Ref) From Note

	if @MaxRef is NULL
		Set @MaxRef = 1 
	else 
		Set @MaxRef = @MaxRef + 1

	Insert Note
	(
		Name, Email, Title, PostIp, Content, RegiNum, Encoding,
		Homepage, Ref, FileName, FileSize, Category
	)
	Values
	(
		@Name, @Email, @Title, @PostIP, @Content, @RegiNum, @Encoding,
		@Homepage, @MaxRef, @FileName, @FileSize, @Category
	)
