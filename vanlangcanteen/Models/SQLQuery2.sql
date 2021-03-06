﻿CREATE TRIGGER TG_ORDER_AUTOCODE
ON [dbo].[ORDER]
FOR INSERT
AS
BEGIN
	DECLARE @ID INT, @ORDER_CODE VARCHAR(10),@NAMHT VARCHAR(2), @THANGHT VARCHAR(2), @MAX INT, @DATE DATETIME, @DAYHT INT

	SET @ID = (SELECT ID FROM INSERTED)
	SET @DATE = (SELECT DATE FROM [dbo].[ORDER]) 
	SET @ORDER_CODE = (SELECT ORDER_CODE FROM INSERTED)
	SET @DAYHT = CONVERT(VARCHAR(2),DAY(@DATE))
	SET @THANGHT = CONVERT(VARCHAR(2), MONTH(@DATE))
	SET @NAMHT = RIGHT(YEAR(@DATE),2)

	IF NOT EXISTS(SELECT 1 FROM [dbo].[ORDER] WHERE LEFT(ORDER_CODE,2) = @NAMHT)
		SET @MAX = 1
	ELSE
		SET @MAX = (SELECT MAX(RIGHT(ORDER_CODE, 2)) FROM [dbo].[ORDER] WHERE LEFT(ORDER_CODE,2) = @NAMHT) + 1
	SET @ORDER_CODE = @NAMHT + @THANGHT + @DAYHT + FORMAT(@MAX, '0000')

	PRINT @ORDER_CODE

	UPDATE [dbo].[ORDER] SET ORDER_CODE = @ORDER_CODE WHERE ID = @ID

END

INSERT INTO [dbo].[ORDER]([DATE],ACCOUNT_ID,CUSTOMER_ID, [STATUS], FEEDBACK) VALUES('01/01/2000', 1, 1, 1,'abc')

SELECT * FROM [dbo].[ORDER]

DELETE [dbo].[ORDER]