CREATE PROCEDURE [dbo].[spAddCustomer]
@BusinessName varchar(50),
@Address varchar(100),
@StartDate datetime,
@EndDate datetime
AS
begin
	set nocount on;

		BEGIN TRY
    BEGIN TRANSACTION
		
		 INSERT INTO [dbo].[Customers] (BusinessName, Address, StartDate, EndDate)
		 VALUES(@BusinessName, @Address, @StartDate, @EndDate)


        COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

		

end