CREATE TABLE [dbo].[Customer_Reps] (
    [CustomerRepId] INT           IDENTITY (1, 1) NOT NULL,
    [First_Name]    VARCHAR (50)  NOT NULL,
    [Last_Name]     VARCHAR (50)  NOT NULL,
    [Address]       VARCHAR (100) NOT NULL,
    [Email]         VARCHAR (50)  NOT NULL,
    [StartDate]     DATETIME      NOT NULL,
    [EndDate]       DATETIME      NOT NULL,
    [ActiveInd]     BIT           NOT NULL,
    [CustomerID]    INT           NOT NULL,
    CONSTRAINT [PK__Projects__761ABED06F3DD31F] PRIMARY KEY CLUSTERED ([CustomerRepId] ASC),
    CONSTRAINT [FK_Customer_Reps_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID])
);

