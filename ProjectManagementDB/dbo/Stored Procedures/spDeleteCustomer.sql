
CREATE PROCEDURE [dbo].[spDeleteCustomer]
@CustomerID int
AS
begin
	set nocount on;

		BEGIN TRY
    BEGIN TRANSACTION
		
		 DELETE FROM [dbo].[Customers]
		 WHERE CustomerID = @CustomerID

        COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

		

end