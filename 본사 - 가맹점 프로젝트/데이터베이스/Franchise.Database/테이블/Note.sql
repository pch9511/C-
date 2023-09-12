--	테이블명: Note
--  기능 : 게시판 정보를 저장하는 DB
--  만든날짜: 2023-03-03

CREATE TABLE [dbo].[Note] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (25)  NOT NULL,
    [Email]        NVARCHAR (100) NULL,
    [Title]        NVARCHAR (150) NOT NULL,
    [PostDate]     DATETIME       DEFAULT (getdate()) NOT NULL,
    [PostIP]       NVARCHAR (15)  NULL,
    [Content]      NTEXT          NOT NULL,
    [RegiNum]     NVARCHAR (30)   NOT NULL,
    [ReadCount]    INT            DEFAULT ((0)) NULL,
    [Encoding]     NVARCHAR (10)  NOT NULL,
    [Homepage]     NVARCHAR (100) NULL,
    [ModifyDate]   DATETIME       NULL,
    [ModifyIP]     NVARCHAR (15)  NULL,
    [FileName]     NVARCHAR (255) NULL,
    [FileSize]     INT            DEFAULT ((0)) NULL,
    [DownCount]    INT            DEFAULT ((0)) NULL,
    [Ref]          INT            NOT NULL,
    [Step]         INT            DEFAULT ((0)) NULL,
    [RefOrder]     INT            DEFAULT ((0)) NULL,
    [AnswerNum]    INT            DEFAULT ((0)) NULL,
    [ParentNum]    INT            DEFAULT ((0)) NULL,
    [CommentCount] INT            DEFAULT ((0)) NULL,
    [Category]     NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

