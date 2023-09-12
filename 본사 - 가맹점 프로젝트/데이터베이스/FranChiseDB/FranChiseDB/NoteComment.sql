--	���̺��: NoteComment
--  ��� : ����� �����ϴ� DB
--  ���糯¥: 2023-03-03

--DROP TABLE [NoteComment]

CREATE TABLE [dbo].[NoteComment] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [BoardName] NVARCHAR (50)   NULL,
    [BoardId]   INT             NOT NULL,
    [Name]      NVARCHAR (25)   NOT NULL,
    [Opinion]   NVARCHAR (4000) NOT NULL,
    [PostDate]  SMALLDATETIME   DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)


SELECT * FROM NoteComment
