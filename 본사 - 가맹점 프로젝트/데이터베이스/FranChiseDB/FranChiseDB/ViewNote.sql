Create Proc ViewNote
	@Id INT
AS
	Update Note Set ReadCount = ReadCount + 1 Where Id = @Id

	Select * From Note WHERE Id = @Id

