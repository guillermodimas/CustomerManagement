
CREATE PROCEDURE [dbo].[spAddCustomerRep]
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
		
		 INSERT INTO [dbo].[Customer_Reps] ([First_Name], [Last_Name], [Address], [Email],[StartDate], [EndDate], [ActiveInd], [CustomerID])
		 VALUES (@First_Name,@Last_Name,@Address,@Email,@StartDate,@EndDate,@ActiveInd,@CustomerID)


        COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

		

end