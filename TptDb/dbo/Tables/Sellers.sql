CREATE TABLE [dbo].[Sellers] (
    [Id]        INT NOT NULL,
    [Inventory] INT NOT NULL,
    CONSTRAINT [PK_FeedLots] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sellers_Contacts_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Contacts] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Sellerss_RegionId]
    ON [dbo].[Sellers]([Inventory] ASC);

