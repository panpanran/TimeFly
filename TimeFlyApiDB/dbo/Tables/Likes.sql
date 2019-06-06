CREATE TABLE [dbo].[Likes] (
    [LikerId] INT NOT NULL,
    [LikeeId] INT NOT NULL,
    CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED ([LikerId] ASC, [LikeeId] ASC),
    CONSTRAINT [FK_Likes_AspNetUsers_LikeeId] FOREIGN KEY ([LikeeId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Likes_AspNetUsers_LikerId] FOREIGN KEY ([LikerId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Likes_LikeeId]
    ON [dbo].[Likes]([LikeeId] ASC);

