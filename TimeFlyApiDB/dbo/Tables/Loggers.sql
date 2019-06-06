CREATE TABLE [dbo].[Loggers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Level]       INT            NOT NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Loggers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

