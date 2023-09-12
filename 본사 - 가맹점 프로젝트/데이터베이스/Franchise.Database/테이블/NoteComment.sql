--	테이블명: NoteComment
--  기능 : 댓글을 저장하는 DB
--  만든날짜: 2023-03-03


CREATE TABLE [dbo].[NoteComment] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [BoardName] NVARCHAR (50)   NULL,
    [BoardId]   INT             NOT NULL,
    [Name]      NVARCHAR (25)   NOT NULL,
    [Opinion]   NVARCHAR (4000) NOT NULL,
    [PostDate]  SMALLDATETIME   DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)