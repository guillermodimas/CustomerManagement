

CREATE PROCEDURE [dbo].[spDeleteCustomerRep]
@CustomerRepId int
AS
begin
	set nocount on;

		BEGIN TRY
    BEGIN TRANSACTION
		
		

		 DELETE FROM [dbo].[Customer_Reps]
		 WHERE CustomerRepId = @CustomerRepId


        COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

		

end