CREATE TABLE [dbo].[Buyers] (
    [Id] INT NOT NULL,
    CONSTRAINT [PK_Buyers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Buyers_Contacts_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Contacts] ([Id]) ON DELETE CASCADE
);

