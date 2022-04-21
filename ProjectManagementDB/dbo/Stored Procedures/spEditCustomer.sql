CREATE PROCEDURE [dbo].[spEditCustomer]
@CustomerID int,
@BusinessName varchar(50),
@Address varchar(100),
@StartDate datetime,
@EndDate datetime
AS
begin
	set nocount on;

	BEGIN TRY
		BEGIN TRANSACTION
		
		  UPDATE [dbo].[Customers] 
		  SET BusinessName = @BusinessName,
		      Address = @Address,
			  StartDate = @StartDate,
			  EndDate = @EndDate
		  WHERE CustomerID = @CustomerID

        COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

		

end