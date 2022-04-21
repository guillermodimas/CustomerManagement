
CREATE PROCEDURE [dbo].[spLoadAllCustomerReps]
	
AS
begin
	set nocount on;

		 SELECT [CustomerRepId], [First_Name] ,[Last_Name] ,[Address]  ,[Email]  ,[StartDate]  ,[EndDate]  ,[ActiveInd]	,[CustomerID]
		 FROM [dbo].[Customer_Reps]

end