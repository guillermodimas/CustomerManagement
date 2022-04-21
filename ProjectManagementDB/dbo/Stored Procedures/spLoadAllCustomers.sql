CREATE PROCEDURE [dbo].[spLoadAllCustomers]
	
AS
begin
	set nocount on;

		 SELECT [CustomerID] ,[BusinessName],[Address],[StartDate], [EndDate] FROM [dbo].[Customers] 

end