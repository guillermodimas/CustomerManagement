CREATE TABLE [dbo].[Customers] (
    [CustomerID]   INT           IDENTITY (1, 1) NOT NULL,
    [BusinessName] VARCHAR (50)  NOT NULL,
    [Address]      VARCHAR (100) NOT NULL,
    [StartDate]    DATETIME      NOT NULL,
    [EndDate]      DATETIME      NOT NULL,
    CONSTRAINT [PK__Companie__2D971C4C3F63F435] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

