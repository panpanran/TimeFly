CREATE TABLE [dbo].[Messages] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [SenderId]         INT            NOT NULL,
    [RecipientId]      INT            NOT NULL,
    [Content]          NVARCHAR (MAX) NULL,
    [IsRead]           BIT            NOT NULL,
    [DateRead]         DATETIME2 (7)  NULL,
    [MessageSent]      DATETIME2 (7)  NOT NULL,
    [SenderDeleted]    BIT            NOT NULL,
    [RecipientDeleted] BIT            NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Messages_AspNetUsers_RecipientId] FOREIGN KEY ([RecipientId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_RecipientId]
    ON [dbo].[Messages]([RecipientId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Messages_SenderId]
    ON [dbo].[Messages]([SenderId] ASC);

