CREATE proc usp_Add_Date

@Date datetime

AS

BEGIN
		
		INSERT INTO tbl_SchDate 
								(dateTime)
								values
								(@Date)
					


END