CREATE TABLE [dbo].[Sales] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Quantity] INT NOT NULL,
    [SellerId] INT NULL,
    [BuyerId]  INT NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sales_Buyers] FOREIGN KEY ([BuyerId]) REFERENCES [dbo].[Buyers] ([Id]),
    CONSTRAINT [FK_Sales_Sellers] FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Sellers] ([Id])
);

