

CREATE PROCEDURE [dbo].[spEditCustomerRep]
@CustomerRepId int,
@First_Name varchar(50),
@Last_Name varchar(50),
@Address varchar(100),
@Email varchar(50),
@StartDate datetime,
@EndDate datetime,
@ActiveInd bit,
@CustomerID int
AS
begin
	set nocount on;

		BEGIN TRY
    BEGIN TRANSACTION
		
		  UPDATE [dbo].[Customer_Reps] 
		  SET [First_Name] = @First_Name,
		      [Last_Name] = @Last_Name,
			  [Address] = @Address,
			  [Email] = @Email,
			  [StartDate] = @StartDate,
			  [EndDate] = @EndDate,
			  [ActiveInd] = @ActiveInd,
			  [CustomerID] = @CustomerID
		  WHERE CustomerRepId = @CustomerRepId

        COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

		

end