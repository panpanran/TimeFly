CREATE TABLE [dbo].[Photos] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Url]         NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [DateAdded]   DATETIME2 (7)  NOT NULL,
    [IsMain]      BIT            NOT NULL,
    [PublicId]    NVARCHAR (MAX) NULL,
    [UserId]      INT            NOT NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Photos_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Photos_UserId]
    ON [dbo].[Photos]([UserId] ASC);

